using Contoso.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contoso.Tests.Data.Base {
    [TestClass] public class NamedDataTests : AbstractTests<NamedData, DescribedData> {
        private class testClass : NamedData { }
        protected override NamedData createObj() => new testClass();
    }
}
