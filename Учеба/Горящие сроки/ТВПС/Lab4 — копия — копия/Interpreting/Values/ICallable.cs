using System.Collections.Generic;
namespace Lab4.Interpreting.Values {
	interface ICallable {
		object Call(IReadOnlyList<object> args);
	}
}
