using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;

namespace entCMS.Common
{
    public class MailHelper
    {
        private static string smtpServer = string.Empty;
        private static string email = string.Empty;
        private static string password = string.Empty;
        private static string sender = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="smtpServer"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        public static void Initialize(string smtpServer, string email, string password, string sender)
        {
            MailHelper.smtpServer = smtpServer;
            MailHelper.email = email;
            MailHelper.password = password;
            MailHelper.sender = sender;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="to">收件人</param>
        /// <param name="cc">抄送人</param>
        /// <param name="bcc">密送人</param>
        /// <param name="message">邮件内容</param>
        /// <param name="isHtml">是否html内容</param>
        /// <returns></returns>
        public static bool SendMail(string[] to, string[] cc, string[] bcc, string subject, string message, bool isBodyHtml, bool useAsync, SendCompletedEventHandler sendCompleted)
        {
            if (string.IsNullOrEmpty(smtpServer)) throw new Exception("邮件发送服务器未指定");
            if (string.IsNullOrEmpty(email)) throw new Exception("发件人邮箱账号未指定");
            if (string.IsNullOrEmpty(password)) throw new Exception("发件人邮箱密码未指定");
            if (to == null || to.Length == 0) throw new Exception("收件人未指定");
            if (string.IsNullOrEmpty(subject)) throw new Exception("邮件主题不能为空");
            if (string.IsNullOrEmpty(message)) throw new Exception("邮件内容不能为空");

            System.Net.Mail.MailMessage msg = new System.Net.Mail.MailMessage();

            if (to != null)
            {
                foreach (var item in to)
                {
                    msg.To.Add(item);
                }
            }
            if (cc != null)
            {
                foreach (var item in cc)
                {
                    msg.CC.Add(item);
                }
            }
            if (bcc != null)
            {
                foreach (var item in bcc)
                {
                    msg.Bcc.Add(item);
                }
            }

            msg.From = new System.Net.Mail.MailAddress(email, sender, Encoding.UTF8);
            msg.Subject = subject;
            msg.SubjectEncoding = Encoding.UTF8;
            msg.Body = message;
            msg.BodyEncoding = Encoding.UTF8;
            msg.IsBodyHtml = isBodyHtml;
            msg.Priority = System.Net.Mail.MailPriority.High;

            System.Net.Mail.SmtpClient smtp = new System.Net.Mail.SmtpClient(smtpServer);
            smtp.Credentials = new System.Net.NetworkCredential(email, password);
            
            object userState = msg;
            try
            {
                if (useAsync)
                {
                    smtp.SendAsync(msg, userState);
                    if (sendCompleted != null) smtp.SendCompleted += sendCompleted;
                }
                else
                {
                    smtp.Send(msg);
                }
                return true;
            }
            catch (SmtpException ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="smtp"></param>
        /// <param name="email"></param>
        /// <param name="pwd"></param>
        /// <param name="sender"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static bool TestSendMail(string smtp, string email, string pwd, string sender, string to)
        {
            MailHelper.Initialize(smtp, email, pwd, sender);

            return SendMail(new string[] { to }, null, null, "邮件发送功能测试", "亲，邮件发送功能测试内容您收到了吗？", false, false, null);
        }
    }
}
