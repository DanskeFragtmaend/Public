using System.Collections.ObjectModel;
using Df.MessagingTypes.Audits;
using Df.MqMessaging;
using Microsoft.Extensions.Options;
using MqAudit = Df.MessagingTypes.Audits.Audit;

namespace Df.AuditLogging.Middleware.Mq;

public class MqAuditLogSource : IAuditLogSource
{
    private readonly IMqPublisher _mqPublisher;
    private readonly MqAuditLogSourceOptions _options;

    public MqAuditLogSource(IMqPublisher mqPublisher, IOptions<MqAuditLogSourceOptions> options)
    {
        _mqPublisher = mqPublisher;
        _options = options.Value;
    }

    public async Task InsertAsync(Audit audit)
    {
        var envelope = new AuditEnvelope
        {
            Payload = MapToMqAudit(audit),
            Publisher = _options.PublisherName,
            CorrelationId = audit.CorrelationId
        };
        await _mqPublisher.PublishAsync(envelope);
    }

    public async Task InsertAsync(IReadOnlyList<Audit> audits)
    {
        foreach (var audit in audits)
        {
            await InsertAsync(audit);
        }
    }

    public Task<ReadOnlyCollection<Audit>> GetAuditsAsync(string dataId, int detailLevel)
    {
        return Task.FromResult(new ReadOnlyCollection<Audit>(Array.Empty<Audit>()));
    }

    private static MqAudit MapToMqAudit(Audit audit)
    {
        return new MqAudit
        {
            Id = audit.Id,
            GroupId = audit.GroupId,
            Action = audit.Action,
            DataType = audit.DataType,
            DataId = audit.DataId,
            DataSubId = audit.DataSubId,
            UserId = audit.UserId,
            Username = audit.UserName,
            TimeStampUtc = audit.TimestampUtc,
            DataFieldName = audit.DataFieldName,
            DataFieldType = audit.DataFieldType,
            DataOldValue = audit.DataOldValue,
            DataNewValue = audit.DataNewValue,
            Source = audit.Source,
            Description = audit.Message,
            Message = audit.Message,
            Version = audit.Version,
            DetailLevel = audit.DetailLevel,
            CorrelationId = audit.CorrelationId
        };
    }
}
