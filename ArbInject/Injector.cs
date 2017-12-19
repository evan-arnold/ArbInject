using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ArbInject
{
    public sealed class Injector
    {
        [DllImport("kernel32.dll")]
        private static extern bool QueryFullProcessImageName(IntPtr hprocess, int dwFlags, StringBuilder lpExeName, out int size);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, uint dwProcessId);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern int CloseHandle(IntPtr hObject);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr GetModuleHandle(string lpModuleName);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, IntPtr dwSize, uint flAllocationType, uint flProtect);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern int WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] buffer, uint size, int lpNumberOfBytesWritten);
        [DllImport("kernel32.dll", SetLastError = true)]
        static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttribute, IntPtr dwStackSize, IntPtr lpStartAddress,
            IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

        public static string GetExecutablePath(Process p)
        {
            if (Environment.OSVersion.Version.Major >= 6)
                return GetExecutablePathAboveVista((uint)p.Id);
            else
                return p.MainModule.FileName;
        }
        private static string GetExecutablePathAboveVista(uint pID)
        {
            var buffer = new StringBuilder(1024);
            IntPtr hprocess = OpenProcess((uint)ProcessAccessFlags.PROCESS_QUERY_LIMITED_INFORMATION, false, pID);
            if (hprocess != IntPtr.Zero)
            {
                try
                {
                    int size = buffer.Capacity;
                    if (QueryFullProcessImageName(hprocess, 0, buffer, out size))
                        return buffer.ToString();
                }
                finally
                {
                    CloseHandle(hprocess);
                }
            }
            return String.Empty; //throw new Win32Exception(Marshal.GetLastWin32Error());
        }

        public static bool Inject(uint pID, string dllPath, out string[] logMessage, out int[] logType)
        {
            logMessage = new string[5];
            logType = new int[5];

            IntPtr hndProc = OpenProcess((uint)ProcessAccessFlags.PROCESS_CREATE_THREAD | (uint)ProcessAccessFlags.PROCESS_QUERY_INFORMATION |
                (uint)ProcessAccessFlags.PROCESS_VM_OPERATION | (uint)ProcessAccessFlags.PROCESS_VM_WRITE | (uint)ProcessAccessFlags.PROCESS_VM_READ, false, (uint)pID);
            if (hndProc != IntPtr.Zero)
            {
                logMessage[0] = "OpenProcess Successful";
                logType[0] = (int)Log.MessageType.Success;
            }
            else
            {
                logMessage[0] = "OpenProcess Unsuccessful";
                logType[0] = (int)Log.MessageType.Error;
                return false;
            }

            IntPtr lpLLAddress = GetProcAddress(GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            if (lpLLAddress != IntPtr.Zero)
            {
                logMessage[1] = "GetProcAddress Successful";
                logType[1] = (int)Log.MessageType.Success;
            }
            else
            {
                logMessage[1] = "GetProcAddress Unsuccessful";
                logType[1] = (int)Log.MessageType.Error;
                return false;
            }

            IntPtr lpAddress = VirtualAllocEx(hndProc, (IntPtr)null, (IntPtr)dllPath.Length, (0x1000 | 0x2000), 0X40);
            if (lpAddress != IntPtr.Zero)
            {
                logMessage[2] = "VirtualAllocEx Successful";
                logType[2] = (int)Log.MessageType.Success;
            }
            else
            {
                logMessage[2] = "VirtualAllocEx Unsuccessful";
                logType[2] = (int)Log.MessageType.Error;
                return false;
            }

            byte[] bytes = Encoding.ASCII.GetBytes(dllPath);

            if (WriteProcessMemory(hndProc, lpAddress, bytes, (uint)bytes.Length, 0) != 0)
            {
                logMessage[3] = "WriteProcessMemory Successful";
                logType[3] = (int)Log.MessageType.Success;
            }
            else
            {
                logMessage[3] = "WriteProcessMemory Unsuccessful";
                logType[3] = (int)Log.MessageType.Error;
                return false;
            }

            if (CreateRemoteThread(hndProc, IntPtr.Zero, IntPtr.Zero, lpLLAddress, lpAddress, 0, IntPtr.Zero) != IntPtr.Zero)
            {
                logMessage[4] = "CreateRemoteThread Successful";
                logType[4] = (int)Log.MessageType.Success;
            }
            else
            {
                logMessage[4] = "CreateRemoteThread Unsuccessful";
                logType[4] = (int)Log.MessageType.Error;
                return false;
            }

            CloseHandle(hndProc);
            return true;
        }

        [Flags]
        private enum ProcessAccessFlags : uint
        {
            PROCESS_ALL_ACCESS = 0x001F0FFF,
            PROCESS_CREATE_PROCESS = 0x0080,
            PROCESS_CREATE_THREAD = 0x0002,
            PROCESS_DUP_HANDLE = 0x0040,
            PROCESS_QUERY_INFORMATION = 0x0400,
            PROCESS_QUERY_LIMITED_INFORMATION = 0x1000,
            PROCESS_SET_INFORMATION = 0x0200,
            PROCESS_SET_QUOTA = 0x0100,
            PROCESS_SUSPEND_RESUME = 0x0800,
            PROCESS_TERMINATE = 0x0001,
            PROCESS_VM_OPERATION = 0x0008,
            PROCESS_VM_READ = 0x0010,
            PROCESS_VM_WRITE = 0x0020,
            SYNCHRONIZE = 0x00100000
        }

        [Flags]
        private enum AllocationTypeFlags : uint
        {
            MEM_COMMIT = 0x00001000,
            MEM_RESERVE = 0x00002000,
            MEM_RESET = 0x00080000,
            MEM_RESET_UNDO = 0x1000000
        }
    }
}
