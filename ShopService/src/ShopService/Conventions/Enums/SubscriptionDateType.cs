using System.ComponentModel.DataAnnotations;

namespace ShopService.Conventions.Enums
{
    public enum SubscriptionDateType
    {
        [Display(Name = "Приостановлено")]
        Suspend = 10,
        [Display(Name = "Подписка начата")]
        Start = 20
    }
}