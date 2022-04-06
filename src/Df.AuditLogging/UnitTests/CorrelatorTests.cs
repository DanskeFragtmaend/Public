using System.Collections.Generic;
using System.Threading.Tasks;
using Df.AuditLogging;
using Moq;
using NUnit.Framework;

namespace UnitTests;

public class CorrelatorTests
{
    [Test]
    public void Test_Correlator_Save_To_Source()
    {
        var sourceMoq = new Mock<IAuditLogSource>();
        sourceMoq.Setup(c => c.InsertAsync(It.IsAny<IReadOnlyList<Audit>>())).Returns(Task.CompletedTask);
        var correlator = new AuditLogCorrelator(sourceMoq.Object);
        correlator.AddAudit(new Audit{Action = AuditActions.Edit});
        correlator.Save();
        sourceMoq.Verify(c => c.InsertAsync(It.IsAny<IReadOnlyList<Audit>>()), Times.Once);
    }
}