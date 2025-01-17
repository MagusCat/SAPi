﻿// <auto-generated />
using System;
using System.Collections.Generic;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Model.Models;

#pragma warning disable 219, 612, 618
#nullable enable

namespace Model.Data.Instance
{
    internal partial class ProductEntityType
    {
        public static RuntimeEntityType Create(RuntimeModel model, RuntimeEntityType? baseEntityType = null)
        {
            var runtimeEntityType = model.AddEntityType(
                "Model.Models.Product",
                typeof(Product),
                baseEntityType);

            var idProduct = runtimeEntityType.AddProperty(
                "IdProduct",
                typeof(int),
                propertyInfo: typeof(Product).GetProperty("IdProduct", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Product).GetField("<IdProduct>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                valueGenerated: ValueGenerated.OnAdd,
                afterSaveBehavior: PropertySaveBehavior.Throw);
            idProduct.AddAnnotation("Relational:ColumnName", "id_product");
            idProduct.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            var active = runtimeEntityType.AddProperty(
                "Active",
                typeof(bool?),
                propertyInfo: typeof(Product).GetProperty("Active", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Product).GetField("<Active>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                nullable: true,
                valueGenerated: ValueGenerated.OnAdd);
            active.AddAnnotation("Relational:ColumnName", "active");
            active.AddAnnotation("Relational:DefaultValueSql", "((1))");
            active.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var idBrand = runtimeEntityType.AddProperty(
                "IdBrand",
                typeof(int),
                propertyInfo: typeof(Product).GetProperty("IdBrand", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Product).GetField("<IdBrand>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            idBrand.AddAnnotation("Relational:ColumnName", "id_brand");
            idBrand.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var idCategory = runtimeEntityType.AddProperty(
                "IdCategory",
                typeof(int),
                propertyInfo: typeof(Product).GetProperty("IdCategory", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Product).GetField("<IdCategory>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            idCategory.AddAnnotation("Relational:ColumnName", "id_category");
            idCategory.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var idUnit = runtimeEntityType.AddProperty(
                "IdUnit",
                typeof(int),
                propertyInfo: typeof(Product).GetProperty("IdUnit", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Product).GetField("<IdUnit>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            idUnit.AddAnnotation("Relational:ColumnName", "id_unit");
            idUnit.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var name = runtimeEntityType.AddProperty(
                "Name",
                typeof(string),
                propertyInfo: typeof(Product).GetProperty("Name", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Product).GetField("<Name>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                maxLength: 80);
            name.AddAnnotation("Relational:ColumnName", "name");
            name.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var price = runtimeEntityType.AddProperty(
                "Price",
                typeof(decimal),
                propertyInfo: typeof(Product).GetProperty("Price", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Product).GetField("<Price>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));
            price.AddAnnotation("Relational:ColumnName", "price");
            price.AddAnnotation("Relational:ColumnType", "money");
            price.AddAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.None);

            var key = runtimeEntityType.AddKey(
                new[] { idProduct });
            runtimeEntityType.SetPrimaryKey(key);
            key.AddAnnotation("Relational:Name", "PK__Product__BA39E84F5970E9A1");

            var index = runtimeEntityType.AddIndex(
                new[] { idBrand });

            var index0 = runtimeEntityType.AddIndex(
                new[] { idCategory });

            var index1 = runtimeEntityType.AddIndex(
                new[] { idUnit });

            return runtimeEntityType;
        }

        public static RuntimeForeignKey CreateForeignKey1(RuntimeEntityType declaringEntityType, RuntimeEntityType principalEntityType)
        {
            var runtimeForeignKey = declaringEntityType.AddForeignKey(new[] { declaringEntityType.FindProperty("IdBrand")! },
                principalEntityType.FindKey(new[] { principalEntityType.FindProperty("IdBrand")! })!,
                principalEntityType,
                deleteBehavior: DeleteBehavior.Cascade,
                required: true);

            var idBrandNavigation = declaringEntityType.AddNavigation("IdBrandNavigation",
                runtimeForeignKey,
                onDependent: true,
                typeof(Brand),
                propertyInfo: typeof(Product).GetProperty("IdBrandNavigation", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Product).GetField("<IdBrandNavigation>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            var products = principalEntityType.AddNavigation("Products",
                runtimeForeignKey,
                onDependent: false,
                typeof(ICollection<Product>),
                propertyInfo: typeof(Brand).GetProperty("Products", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Brand).GetField("<Products>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            runtimeForeignKey.AddAnnotation("Relational:Name", "fk_brand");
            return runtimeForeignKey;
        }

        public static RuntimeForeignKey CreateForeignKey2(RuntimeEntityType declaringEntityType, RuntimeEntityType principalEntityType)
        {
            var runtimeForeignKey = declaringEntityType.AddForeignKey(new[] { declaringEntityType.FindProperty("IdCategory")! },
                principalEntityType.FindKey(new[] { principalEntityType.FindProperty("IdCategory")! })!,
                principalEntityType,
                deleteBehavior: DeleteBehavior.Cascade,
                required: true);

            var idCategoryNavigation = declaringEntityType.AddNavigation("IdCategoryNavigation",
                runtimeForeignKey,
                onDependent: true,
                typeof(Category),
                propertyInfo: typeof(Product).GetProperty("IdCategoryNavigation", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Product).GetField("<IdCategoryNavigation>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            var products = principalEntityType.AddNavigation("Products",
                runtimeForeignKey,
                onDependent: false,
                typeof(ICollection<Product>),
                propertyInfo: typeof(Category).GetProperty("Products", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Category).GetField("<Products>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            runtimeForeignKey.AddAnnotation("Relational:Name", "fk_category");
            return runtimeForeignKey;
        }

        public static RuntimeForeignKey CreateForeignKey3(RuntimeEntityType declaringEntityType, RuntimeEntityType principalEntityType)
        {
            var runtimeForeignKey = declaringEntityType.AddForeignKey(new[] { declaringEntityType.FindProperty("IdUnit")! },
                principalEntityType.FindKey(new[] { principalEntityType.FindProperty("IdUnit")! })!,
                principalEntityType,
                required: true);

            var idUnitNavigation = declaringEntityType.AddNavigation("IdUnitNavigation",
                runtimeForeignKey,
                onDependent: true,
                typeof(Unit),
                propertyInfo: typeof(Product).GetProperty("IdUnitNavigation", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Product).GetField("<IdUnitNavigation>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            var products = principalEntityType.AddNavigation("Products",
                runtimeForeignKey,
                onDependent: false,
                typeof(ICollection<Product>),
                propertyInfo: typeof(Unit).GetProperty("Products", BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly),
                fieldInfo: typeof(Unit).GetField("<Products>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly));

            runtimeForeignKey.AddAnnotation("Relational:Name", "fk_unit");
            return runtimeForeignKey;
        }

        public static void CreateAnnotations(RuntimeEntityType runtimeEntityType)
        {
            runtimeEntityType.AddAnnotation("Relational:FunctionName", null);
            runtimeEntityType.AddAnnotation("Relational:Schema", null);
            runtimeEntityType.AddAnnotation("Relational:SqlQuery", null);
            runtimeEntityType.AddAnnotation("Relational:TableName", "Product");
            runtimeEntityType.AddAnnotation("Relational:ViewName", null);
            runtimeEntityType.AddAnnotation("Relational:ViewSchema", null);

            Customize(runtimeEntityType);
        }

        static partial void Customize(RuntimeEntityType runtimeEntityType);
    }
}
