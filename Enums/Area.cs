using System;
using System.ComponentModel;

namespace ChoosingBot.Enums
{
    [Flags]
    public enum Area
    {
        None = 0,

        [Description("吳興街")]
        WuxingStreat = 1,

        [Description("美食街")]
        FoodStreet = 2,

        [Description("速食")]
        FastFood = 4

    }
}