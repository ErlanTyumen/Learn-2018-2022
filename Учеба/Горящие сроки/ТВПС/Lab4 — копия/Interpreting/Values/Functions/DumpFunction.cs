using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
namespace Lab4.Interpreting.Values.Functions {
	sealed class DumpFunction : ICallable, IDumpable, IReferenceEquatable {
		public object Call(IReadOnlyList<object> args) {
			Console.WriteLine(string.Join(" ", args.Select(ValueToString)));
			return this;
		}
		public string GetDumpString() {
			return "dump";
		}
		public static string ValueToString(object value) {
			if (value == null) {
				return "null";
			}
			if (value is bool) {
				return (bool)value ? "true" : "false";
			}
			if (value is BigInteger) {
				return ((BigInteger)value).ToString(NumberFormatInfo.InvariantInfo);
			}
			if (value is IDumpable) {
				return ((IDumpable)value).GetDumpString();
			}
			if (value is string) {
				return (string)value;
			}
			throw new Exception($"Неизвестный тип значения {value}");
		}
	}
}
