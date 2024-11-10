﻿// <auto-generated />
using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Metadata;
using Model.Models;

#pragma warning disable 219, 612, 618
#nullable enable

namespace Model.Data.Instance
{
    internal partial class ConversionEntityType
    {
        public static RuntimeEntityType Create(RuntimeModel model, RuntimeEntityType? baseEntityType = null)
        {
            var runtimeEntityType = model.AddEntityType(
                "Model.Models.Conversion",
                typeof(Conversion),
                baseEntityType);

            var idConversion = runtimeEntityType.AddProperty(
                "IdConversion",
                typeof(int),
                propertyInfo: typeof(Conversion).GetProperty("IdConversion", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Conversion).GetField("<IdConversion>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                valueGenerated: ValueGenerated.OnAdd,
                afterSaveBehavior: PropertySaveBehavior.Throw);
            idConversion.AddAnnotation("Relational:ColumnName", "id_conversion");
            idConversion.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            var factor = runtimeEntityType.AddProperty(
                "Factor",
                typeof(double?),
                propertyInfo: typeof(Conversion).GetProperty("Factor", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Conversion).GetField("<Factor>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true);
            factor.AddAnnotation("Relational:ColumnName", "factor");
            factor.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var idBase = runtimeEntityType.AddProperty(
                "IdBase",
                typeof(int),
                propertyInfo: typeof(Conversion).GetProperty("IdBase", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Conversion).GetField("<IdBase>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            idBase.AddAnnotation("Relational:ColumnName", "id_base");
            idBase.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var idFactor = runtimeEntityType.AddProperty(
                "IdFactor",
                typeof(int),
                propertyInfo: typeof(Conversion).GetProperty("IdFactor", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Conversion).GetField("<IdFactor>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            idFactor.AddAnnotation("Relational:ColumnName", "id_factor");
            idFactor.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var key = runtimeEntityType.AddKey(
                new[] { idConversion });
            runtimeEntityType.SetPrimaryKey(key);
            key.AddAnnotation("Relational:Name", "PK__Conversi__B8BBCE5A6532139F");

            var index = runtimeEntityType.AddIndex(
                new[] { idBase });

            var index0 = runtimeEntityType.AddIndex(
                new[] { idFactor });

            return runtimeEntityType;
        }

        public static RuntimeForeignKey CreateForeignKey1(RuntimeEntityType declaringEntityType, RuntimeEntityType principalEntityType)
        {
            var runtimeForeignKey = declaringEntityType.AddForeignKey(new[] { declaringEntityType.FindProperty("IdBase")! },
                principalEntityType.FindKey(new[] { principalEntityType.FindProperty("IdUnit")! })!,
                principalEntityType,
                required: true);

            var idBaseNavigation = declaringEntityType.AddNavigation("IdBaseNavigation",
                runtimeForeignKey,
                onDependent: true,
                typeof(Unit),
                propertyInfo: typeof(Conversion).GetProperty("IdBaseNavigation", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Conversion).GetField("<IdBaseNavigation>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            var conversionIdBaseNavigations = principalEntityType.AddNavigation("ConversionIdBaseNavigations",
                runtimeForeignKey,
                onDependent: false,
                typeof(ICollection<Conversion>),
                propertyInfo: typeof(Unit).GetProperty("ConversionIdBaseNavigations", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Unit).GetField("<ConversionIdBaseNavigations>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            runtimeForeignKey.AddAnnotation("Relational:Name", "fk_base_unit");
            return runtimeForeignKey;
        }

        public static RuntimeForeignKey CreateForeignKey2(RuntimeEntityType declaringEntityType, RuntimeEntityType principalEntityType)
        {
            var runtimeForeignKey = declaringEntityType.AddForeignKey(new[] { declaringEntityType.FindProperty("IdFactor")! },
                principalEntityType.FindKey(new[] { principalEntityType.FindProperty("IdUnit")! })!,
                principalEntityType,
                required: true);

            var idFactorNavigation = declaringEntityType.AddNavigation("IdFactorNavigation",
                runtimeForeignKey,
                onDependent: true,
                typeof(Unit),
                propertyInfo: typeof(Conversion).GetProperty("IdFactorNavigation", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Conversion).GetField("<IdFactorNavigation>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            var conversionIdFactorNavigations = principalEntityType.AddNavigation("ConversionIdFactorNavigations",
                runtimeForeignKey,
                onDependent: false,
                typeof(ICollection<Conversion>),
                propertyInfo: typeof(Unit).GetProperty("ConversionIdFactorNavigations", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Unit).GetField("<ConversionIdFactorNavigations>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            runtimeForeignKey.AddAnnotation("Relational:Name", "fk_factor_unit");
            return runtimeForeignKey;
        }

        public static void CreateAnnotations(RuntimeEntityType runtimeEntityType)
        {
            runtimeEntityType.AddAnnotation("Relational:FunctionName", null);
            runtimeEntityType.AddAnnotation("Relational:Schema", null);
            runtimeEntityType.AddAnnotation("Relational:SqlQuery", null);
            runtimeEntityType.AddAnnotation("Relational:TableName", "Conversion");
            runtimeEntityType.AddAnnotation("Relational:ViewName", null);
            runtimeEntityType.AddAnnotation("Relational:ViewSchema", null);

            Customize(runtimeEntityType);
        }

        static partial void Customize(RuntimeEntityType runtimeEntityType);
    }
}
