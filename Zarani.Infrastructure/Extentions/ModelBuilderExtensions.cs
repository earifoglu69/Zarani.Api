using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zarani.Infrastructure.Models;

namespace Zarani.Infrastructure.Extentions
{

    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ModuleEntity>().HasData(
                new ModuleEntity { Id = 1, Name = "Menu" },
                new ModuleEntity { Id = 2, Name = "Brand" },
                new ModuleEntity { Id = 3, Name = "Campaign" },
                new ModuleEntity { Id = 4, Name = "Comment" },
                new ModuleEntity { Id = 5, Name = "Content" },
                new ModuleEntity { Id = 6, Name = "Faq" },
                new ModuleEntity { Id = 7, Name = "FaqCategory" },
                new ModuleEntity { Id = 8, Name = "LandingPage" },
                new ModuleEntity { Id = 9, Name = "Model" },
                new ModuleEntity { Id = 10, Name = "ModelGallery" },
                new ModuleEntity { Id = 11, Name = "News" },
                new ModuleEntity { Id = 12, Name = "NewsGallery" },
                new ModuleEntity { Id = 13, Name = "Slider" },
                new ModuleEntity { Id = 14, Name = "Product" }
            );

            modelBuilder.Entity<ContentEntity>().HasData(
                new ContentEntity { Id = 1, ModuleId = 1, Name = "Tüm Kategoriler", Permalink="" },
                new ContentEntity { Id = 2, ModuleId = 1, ParentId = 1, Name = "Tv Koltuğu", Permalink = "tv-koltugu" },
                new ContentEntity { Id = 3, ModuleId = 1, ParentId = 1, Name = "Baba Koltuğu", Permalink = "baba-koltugu" },
                new ContentEntity { Id = 4, ModuleId = 1, ParentId = 1, Name = "Hasta Koltuğu", Permalink = "hasta-koltugu" },
                new ContentEntity { Id = 5, ModuleId = 1, ParentId = 1, Name = "Sinema Koltuğu", Permalink = "sinema-koltugu" },

                new ContentEntity { Id = 6, ModuleId = 1, Name = "Üst Menü", Permalink="" },
                new ContentEntity { Id = 7, ModuleId = 1, ParentId = 6, Name = "Anasayfa", Permalink = "" },
                new ContentEntity { Id = 8, ModuleId = 1, ParentId = 6, Name = "Kargom Nerede", Permalink = "kargom-nerede" },
                new ContentEntity { Id = 9, ModuleId = 1, ParentId = 6, Name = "Yardım", Permalink = "yardim" },
                new ContentEntity { Id = 10, ModuleId = 1, ParentId = 6, Name = "Siparişlerim", Permalink = "siparislerim" },

                new ContentEntity { Id = 11, ModuleId = 1, Name = "Orta Menü", Permalink = "iletisim" },
                new ContentEntity { Id = 12, ModuleId = 1, ParentId = 11, Name = "İletisim", Permalink = "iletisim" },
                new ContentEntity { Id = 13, ModuleId = 1, ParentId = 11, Name = "Yeni Ürünler", Permalink = "yeni-urunler" },
                new ContentEntity { Id = 14, ModuleId = 1, ParentId = 11, Name = "Fırsat Ürünleri", Permalink = "firsat-urunleri" },


                new ContentEntity { Id = 15, ModuleId = 1, Name = "Orta Menü" ,Permalink = "" },
                new ContentEntity { Id = 16, ModuleId = 1, ParentId = 15, Name = "İletisim", Permalink = "iletisim" },
                new ContentEntity { Id = 17, ModuleId = 1, ParentId = 15, Name = "Yeni Ürünler", Permalink = "yeni-urunler" },
                new ContentEntity { Id = 18, ModuleId = 1, ParentId = 15, Name = "Fırsat Ürünleri", Permalink = "firsat-urunleri" },

                new ContentEntity { Id = 19, ModuleId = 1, Name = "Kurumsal", Permalink="" },
                new ContentEntity { Id = 20, ModuleId = 1, ParentId = 19, Name = "Güvenli Alışveriş", Permalink = "iletisim" },
                new ContentEntity { Id = 21, ModuleId = 1, ParentId = 19, Name = "Hakkımızda", Permalink = "yeni-urunler" },
                new ContentEntity { Id = 22, ModuleId = 1, ParentId = 19, Name = "Bize Ulaşın", Permalink = "firsat-urunleri" }

                );

        }
    }
}
