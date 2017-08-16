namespace nyom.infra.CrossCutting.Helper
{
    public enum WorkflowStatus
    {
		Ready,
	    WorkflowManager,
		WorkFlowManagerCompleted,
		MessageBuilder,
		MessageBuilderCompleted,
		QueueBuilder,
		QueueBuilderCompleted,
		PushSender,
		PushSenderCompleted,
		LoggingCleanup,
		LoggingCleanupCompleted,
        Finished,
		Error
	}
}
