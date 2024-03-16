using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreDB_HW.Models;
[Table("UsersTable")]
public class User
{
    [Key]
    public int Id { get; set; }
    [Required]
    [StringLength(64)]
    public string Name { get; set; }
    [Required]
    [StringLength(32)]
    public string Login { get; set; }
    [Required]
    [StringLength(32)]
    public string Password { get; set; }
}
