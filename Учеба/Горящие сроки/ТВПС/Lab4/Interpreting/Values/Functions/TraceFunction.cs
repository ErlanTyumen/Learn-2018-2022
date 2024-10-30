using System;
using System.Collections.Generic;
namespace Lab4.Interpreting.Values.Functions {
	sealed class TraceFunction : ICallable, IDumpable, IReferenceEquatable {
		public object Call(IReadOnlyList<object> args) {
			if (args.Count != 1) {
				throw new Exception($"Нужен 1 аргумент, а не {args.Count}: {string.Join(", ", args)}");
			}
			Console.WriteLine($">> {DumpFunction.ValueToString(args[0])}");
			return args[0];
		}
		public string GetDumpString() {
			return "trace";
		}
	}
}
