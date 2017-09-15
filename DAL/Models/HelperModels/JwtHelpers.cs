﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models.HelperModels
{
    public static class JwtHelpers
    {
        public static class Strings
        {
            public static class JwtClaimIdentifiers
            {
                public const string Rol = "rol", Id = "id";
            }

            public static class JwtClaims
            {
                public const string ApiAccess = "api_access";
            }
        }
    }
}
