namespace ET.Server
{
    public static partial class MailHelper
    {
        public static void SendMail(this Unit unit, Mail mail)
        {
            unit.GetComponent<MailComponent>().AddMail(mail);
        }

        public static void SendMail(long unitId, Mail mail)
        {
            
        }
    }
}