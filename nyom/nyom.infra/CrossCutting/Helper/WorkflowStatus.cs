namespace nyom.infra.CrossCutting.Helper
{
    public enum WorkflowStatus
    {
		Ready,
		MessageBuilder,
		MessageBuilderCompleted,
		QueueBuilder,
		QueueBuilderCompleted,
		PushSender,
		PushSenderCompleted,
		LoggingCleanup,
		Finished,
		Error
    }
}
