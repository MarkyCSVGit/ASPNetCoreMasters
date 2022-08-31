using System.ComponentModel.DataAnnotations;

namespace ASPNetCoreMastersTodoList.Api.BindingModels
{
    public class ItemCreateBindingModel
    {
        [Required(ErrorMessage = "You should provide a name value.")]
        [StringLength(128), MinLength(1)]

        public string Text { get; set; } = string.Empty;
    }
}
