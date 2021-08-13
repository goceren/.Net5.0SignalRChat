using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRChat.Core.Utilities
{
    public class Enums
    {
        public enum StateEnum
        {
            [System.ComponentModel.Description("Pasif")]
            Passive = 0,
            [System.ComponentModel.Description("Aktif")]
            Active = 1,
            [System.ComponentModel.Description("Silindi")]
            Deleted = 2,
            [System.ComponentModel.Description("Erişim Engellendi")]
            Blocked = 3
        }
        public enum StatusEnum
        {
            [System.ComponentModel.Description("Hata Oluştu")]
            Error = 0,
            [System.ComponentModel.Description("Başarılı")]
            Successful = 1,
            [System.ComponentModel.Description("Uyarı")]
            Warning = 2,
            [System.ComponentModel.Description("Veri Yok")]
            EmptyData = 3,
            [System.ComponentModel.Description("Tanımlanmamış")]
            Undefined = 4,
            [System.ComponentModel.Description("Bilgi")]
            Info = 5,
            [System.ComponentModel.Description("Evet / Hayır")]
            Confirm = 6,
        }
    }
}
