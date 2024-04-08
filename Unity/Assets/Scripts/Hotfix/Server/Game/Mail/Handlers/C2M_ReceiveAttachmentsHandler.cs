namespace ET.Server
{
    [MessageHandler(SceneType.Map)]
    public class C2M_ReceiveAttachmentsHandler : MessageLocationHandler<Unit, C2M_ReceiveAttachments, M2C_ReceiveAttachments>
    {
        protected override async ETTask Run(Unit unit, C2M_ReceiveAttachments request, M2C_ReceiveAttachments response)
        {
            long mailId = request.MailId;
            if (mailId < 1)
            {
                response.Error = ErrorCode.ERR_MailIdInvalid;
                response.Message = "邮箱id无效";
                return;
            }
            
            Mail mail = unit.GetComponent<MailComponent>().ReceiveMailAttachments(mailId);
            if (mail == null)
            {
                response.Error = ErrorCode.ERR_MailIdNotFound;
                response.Message = "邮箱id未找到";
                return;
            }

            response.MailInfo = mail.ToMessage();
            
            await ETTask.CompletedTask;
        }
    }
}