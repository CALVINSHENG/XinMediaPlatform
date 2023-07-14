using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MicroServiceCoreLibrary.Models.AuthLogin
{
#pragma warning disable CS8618 // 退出建構函式時，不可為 Null 的欄位必須包含非 Null 值。請考慮宣告為可為 Null。

    /// <summary>
    /// 職位主表
    /// </summary>
    public class TGroups
    {
        [Key]
        public int NO { get; set; }

        [Column("GROUP_NO")]
        [DisplayName("GROUP_NO")]
        [Required]
        [StringLength(10, ErrorMessage = "GROUP_NO不可超過10字")]
        public string GROUP_NO { get; set; }

        [Column("GROUP_NAME")]
        [DisplayName("GROUP_NAME")]
        [Required]
        [StringLength(10, ErrorMessage = "GROUP_NAME不可超過10字")]
        public string GROUP_NAME { get; set; }

        [Column("USER_NO")]
        [DisplayName("USER_NO")]
        [Required]
        [StringLength(10, ErrorMessage = "USER_NO不可超過10字")]
        public string user_no { get; set; }

        public string DESCRIPTION { get; set; }

        [Column("COMPANY_NO")]
        [DisplayName("COMPANY_NO")]
        [Required]
        [StringLength(10, ErrorMessage = "COMPANY_NO不可超過10字")]
        public string COMPANY_NO { get; set; }

        [Column("GROUP_STATUS")]
        [DisplayName("GROUP_STATUS")]
        [Required]
        [StringLength(1, ErrorMessage = "GROUP_STATUS不可超過1字")]
        public string GROUP_STATUS { get; set; }

        [Column("CREID")]
        [DisplayName("CREID")]
        [Required]
        [StringLength(10, ErrorMessage = "CREID不可超過10字")]
        public string CREID { get; set; }

        [Column("CREDATE")]
        [DisplayName("CREDATE")]
        [Required]
        public DateTime? CREDATE { get; set; }

        [Column("UPDID")]
        [DisplayName("UPDID")]
        [StringLength(10, ErrorMessage = "UPDID不可超過10字")]
        public string UPDID { get; set; }

        [Column("UPDDATE")]
        [DisplayName("UPDDATE")]
        public DateTime? UPDDATE { get; set; }

    }
}
