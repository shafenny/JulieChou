namespace HomeWork1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(客戶聯絡人MetaData))]
    public partial class 客戶聯絡人 : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var db = new 客戶資料Entities();

            var data = db.客戶資料.Find(客戶Id).客戶聯絡人;

            foreach (var item in data)
            {
                if (Email == item.Email)
                {
                    yield return new ValidationResult("同一個客戶下的聯絡人，其 Email 不能重複", new[] { "Email" });
                }
            }
        }

        public partial class 客戶聯絡人MetaData
        {
            [Required]
            public int Id { get; set; }
            [Required]
            public int 客戶Id { get; set; }

            [StringLength(50, ErrorMessage = "欄位長度不得大於 50 個字元")]
            [Required]
            public string 職稱 { get; set; }

            [StringLength(50, ErrorMessage = "欄位長度不得大於 50 個字元")]
            [Required(ErrorMessage = "聯絡人姓名為必填欄位")]
            public string 姓名 { get; set; }

            [StringLength(250, ErrorMessage = "欄位長度不得大於 250 個字元")]
            [Required(ErrorMessage = "聯絡人Email為必填欄位")]
            public string Email { get; set; }

            [StringLength(20, ErrorMessage = "欄位長度不得大於 20 個字元")]
            [RegularExpression(@"\d{4}-\d{6}", ErrorMessage = "請輸入正確的電話格式 ( e.g. 0911-111111 )")]
            public string 手機 { get; set; }

            [StringLength(50, ErrorMessage = "欄位長度不得大於 50 個字元")]
            public string 電話 { get; set; }
            [Required]
            public bool isDeleted { get; set; }

            public virtual 客戶資料 客戶資料 { get; set; }
        }
    }
}
