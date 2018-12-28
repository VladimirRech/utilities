using System;
using System.Diagnostics;

public static class memusg {

 static void Main(string[] args)
 {
    if(args == null || args.Length == 0) {
        Console.WriteLine("Usage: memusg <process name>");
        return;
    }
  getallmemoryusage(args[0]);
  //Console.ReadLine();
 }

 private static void getallmemoryusage(string pName)
 {
  /*
  PrivateMemorySize
  The number of bytes that the associated process has allocated that cannot be shared with other processes.
  PeakVirtualMemorySize
  The maximum amount of virtual memory that the process has requested.
  PeakPagedMemorySize
  The maximum amount of memory that the associated process has allocated that could be written to the virtual paging file.
  PagedSystemMemorySize
  The amount of memory that the system has allocated on behalf of the associated process that can be written to the virtual memory paging file.
  PagedMemorySize
  The amount of memory that the associated process has allocated that can be written to the virtual memory paging file.
  NonpagedSystemMemorySize
  The amount of memory that the system has allocated on behalf of the associated process that cannot be written to the virtual memory paging file.
  */
  double f = 1024.0;
  Process[] localByName = Process.GetProcessesByName(pName.ToLower());
  decimal max = 0m;
  foreach (Process p in localByName)
  {
      max += (decimal)(p.PrivateMemorySize64 / f / f);
	//   Console.WriteLine("Private memory size64: {0}", (p.PrivateMemorySize64 / f).ToString("#,##0"));
	//   Console.WriteLine("Working Set size64: {0}", (p.WorkingSet64/f).ToString("#,##0"));
	//   Console.WriteLine("Peak virtual memory size64: {0}", (p.PeakVirtualMemorySize64 / f).ToString("#,##0"));
	//   Console.WriteLine("Peak paged memory size64: {0}", (p.PeakPagedMemorySize64 / f).ToString("#,##0"));
	//   Console.WriteLine("Paged system memory size64: {0}", (p.PagedSystemMemorySize64 / f).ToString("#,##0"));
	//   Console.WriteLine("Paged memory size64: {0}", (p.PagedMemorySize64 / f).ToString("#,##0"));
	//   Console.WriteLine("Nonpaged system memory size64: {0}", (p.NonpagedSystemMemorySize64 / f).ToString("#,##0"));
  }
  Console.WriteLine("Total private memory usage: {0:N0} MB", max);
 }
}