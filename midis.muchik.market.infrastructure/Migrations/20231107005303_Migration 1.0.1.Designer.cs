﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using midis.muchik.market.infrastructure.context;

#nullable disable

namespace midis.muchik.market.infrastructure.Migrations
{
    [DbContext(typeof(OmnichannelContext))]
    [Migration("20231107005303_Migration 1.0.1")]
    partial class Migration101
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("midis.muchik.market.domain.entities.Order", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("varchar(250)")
                        .HasColumnName("id");

                    b.Property<string>("Correlative")
                        .IsRequired()
                        .HasColumnType("varchar(25)")
                        .HasColumnName("correlative");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp")
                        .HasColumnName("created_at");

                    b.Property<string>("CustomerId")
                        .IsRequired()
                        .HasColumnType("varchar(250)")
                        .HasColumnName("customer_id");

                    b.Property<short>("State")
                        .HasColumnType("smallint")
                        .HasColumnName("state");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal")
                        .HasColumnName("total");

                    b.HasKey("Id");

                    b.ToTable("order", (string)null);
                });

            modelBuilder.Entity("midis.muchik.market.domain.entities.OrderDetail", b =>
                {
                    b.Property<string>("OrderId")
                        .HasColumnType("varchar(250)")
                        .HasColumnName("order_id");

                    b.Property<string>("ProductId")
                        .HasColumnType("varchar(250)")
                        .HasColumnName("product_id");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal")
                        .HasColumnName("price");

                    b.Property<short>("Quantity")
                        .HasColumnType("smallint")
                        .HasColumnName("quantity");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal")
                        .HasColumnName("total");

                    b.HasKey("OrderId", "ProductId");

                    b.ToTable("order_detail", (string)null);
                });

            modelBuilder.Entity("midis.muchik.market.domain.entities.OrderDetail", b =>
                {
                    b.HasOne("midis.muchik.market.domain.entities.Order", "Order")
                        .WithMany("OrderDetail")
                        .HasForeignKey("OrderId")
                        .IsRequired()
                        .HasConstraintName("FK_order_orderdetail");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("midis.muchik.market.domain.entities.Order", b =>
                {
                    b.Navigation("OrderDetail");
                });
#pragma warning restore 612, 618
        }
    }
}
