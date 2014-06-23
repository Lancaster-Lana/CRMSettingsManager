using System.Globalization;

namespace LanaSoft.ConfigDatabase.Business
{
    public class EndPoint : BusinessType
    {
        public EndPoint()
        {
            ListenHost = string.Empty;
            AnswerHost = string.Empty;
            AnswerPort = 0;
            ListenPort = 0;
        }

        public override string Description
        {
            get
            {
                return ListenHost + " : "+ ListenPort.ToString(CultureInfo.InvariantCulture);
            }
        }

        public override bool Equals(BusinessType obj)
        {
            var toObj = obj as EndPoint;

            if (toObj != null && (toObj.AnswerHost.Equals(this.AnswerHost)
                                  && toObj.AnswerPort.Equals(this.AnswerPort)
                                  && toObj.ListenHost.Equals(this.ListenHost)
                                  && toObj.ListenPort.Equals(this.ListenPort)
                                  && base.Equals(obj)))
                return true;
            return false;
        }

        public string ListenHost { get; set; }

        public int ListenPort { get; set; }

        public string AnswerHost { get; set; }

        public int AnswerPort { get; set; }
    }
}
