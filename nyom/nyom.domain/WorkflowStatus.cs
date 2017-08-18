namespace nyom.domain
{
    public enum WorkflowStatus
    {
        Ready = 0,
        WorkflowManager = 1,
        WorkFlowManagerCompleted = 2,
        MessageBuilder = 3,
        MessageBuilderCompleted = 4,
        QueueBuilder = 5,
        QueueBuilderCompleted = 6,
        PushSender = 7,
        PushSenderCompleted = 8,
        LoggingCleanup = 9,
        LoggingCleanupCompleted = 10,
        Finished = 11,
        Error = 12,
        Blocked = 13,
        Cancelled = 14
    }
}
