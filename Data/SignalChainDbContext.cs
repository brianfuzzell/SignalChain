using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SignalChain.Models;
using Microsoft.AspNetCore.Identity;

namespace SignalChain.Data;

public class SignalChainDbContext : IdentityDbContext<IdentityUser>
{
    private readonly IConfiguration _configuration;
    public DbSet<Gear> Gears { get; set; }
    public DbSet<Song> Songs { get; set; }
    public DbSet<GearSong> GearSongs { get; set; }
    public DbSet<GearType> GearTypes { get; set; }
    public DbSet<Status> Statuses { get; set; }

    public SignalChainDbContext(DbContextOptions<SignalChainDbContext> context, IConfiguration config) : base(context)
    {
        _configuration = config;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
        {
            Id = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            Name = "Owner",
            NormalizedName = "owner"
        });

        modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
        {
            Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            UserName = "Owner",
            Email = "owner@signalchain.comx",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
        },

        new IdentityUser
        {
            Id = "8f7b2e4a-1c3d-4f6e-9a8b-5d2c1e0f3a4b",
            UserName = "bschmidt",
            Email = "bschmidt@signalchain.comx",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
        },

        new IdentityUser
        {
            Id = "2a4c6e8f-3b5d-4a7c-8e9f-1d3c5b7a9e0d",
            UserName = "mjones",
            Email = "mjones@signalchain.comx",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
        }
        );


        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f"
        });
        modelBuilder.Entity<UserProfile>().HasData(new UserProfile
        {
            Id = 1,
            IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            FirstName = "Admina",
            LastName = "Strator",
            Address = "101 Main Street",
        },
        new UserProfile
        {
            Id = 2,
            IdentityUserId = "8f7b2e4a-1c3d-4f6e-9a8b-5d2c1e0f3a4b",
            FirstName = "Burt",
            LastName = "Schmidt",
            Address = "202 Oak Avenue",
        },
        new UserProfile
        {
            Id = 3,
            IdentityUserId = "2a4c6e8f-3b5d-4a7c-8e9f-1d3c5b7a9e0d",
            FirstName = "Miranda",
            LastName = "Jones",
            Address = "303 Pine Street",
        });

        modelBuilder.Entity<Gear>().HasData(new Gear[]
        {
            new Gear
            {
                Id = 1,
                GearTypeId = 1,
                Model = "Apple MacBook Air 2020 M1",
                PurchaseYear = "2021",
                Quantity = 1,
                SerialNumber = "FVFQHNACQ6L7"
            },
            new Gear
            {
                Id = 2,
                GearTypeId = 2,
                Model = "Studio Projects B1 Matched Pair lrg dia microphones",
                PurchaseYear = "N/A",
                Quantity = 1,
                SerialNumber = "SPB1X9876"
            },
            new Gear
            {
                Id = 3,
                GearTypeId = 2,
                Model = "Studio Projects B1 lrg dia microphone",
                PurchaseYear = "2024",
                Quantity = 1,
                SerialNumber = "SPB1X12345"
            },
            new Gear
            {
                Id = 4,
                GearTypeId = 2,
                Model = "Audix i5 microphone",
                PurchaseYear = "2024",
                Quantity = 2,
                SerialNumber = "N/A"
            },
            new Gear
            {
                Id = 5,
                GearTypeId = 3,
                Model = "Zildjian K hi-hats pair 14-inch",
                PurchaseYear = "2003",
                Quantity = 1,
                SerialNumber = "Top: JC 24956-097, Bottom: JC 24964-085"
            },
            new Gear
            {
                Id = 6,
                GearTypeId = 3,
                Model = "Sabian AAX Metal crash 16-inch",
                PurchaseYear = "2004",
                Quantity = 1,
                SerialNumber = "N/A"
            },
            new Gear
            {
                Id = 7,
                GearTypeId = 3,
                Model = "Zildjian A Medium-Thin crash 18-inch",
                PurchaseYear = "2017",
                Quantity = 1,
                SerialNumber = "AG85199 061"
            },
            new Gear
            {
                Id = 8,
                GearTypeId = 3,
                Model = "Zildjian A Medium-Thin crash 19-inch",
                PurchaseYear = "2005",
                Quantity = 1,
                SerialNumber = "JE 43363 006"
            },
            new Gear
            {
                Id = 9,
                GearTypeId = 3,
                Model = "Zildjian K Custom Medium ride 20-inch",
                PurchaseYear = "2004",
                Quantity = 1,
                SerialNumber = "JB 23527-016"
            },
            new Gear
            {
                Id = 10,
                GearTypeId = 3,
                Model = "Gretsch Brooklyn 6.5x14 snare GB4164S",
                PurchaseYear = "2023",
                Quantity = 1,
                SerialNumber = "033239"
            },
            new Gear
            {
                Id = 11,
                GearTypeId = 3,
                Model = "Gretsch Brooklyn Series drums",
                PurchaseYear = "2024",
                Quantity = 3,
                SerialNumber = "021463, 021452, 021467"
            },
            new Gear
            {
                Id = 12,
                GearTypeId = 3,
                Model = "Fender 1105 SXE",
                PurchaseYear = "1996",
                Quantity = 1,
                SerialNumber = "9091202"
            },
            new Gear
            {
                Id = 13,
                GearTypeId = 3,
                Model = "Digital Piano 88-Key Keyboard",
                PurchaseYear = "2025",
                Quantity = 1,
                SerialNumber = "N/A"
            },
            new Gear
            {
                Id = 14,
                GearTypeId = 3,
                Model = "Trombone Blessing BTB1488O",
                PurchaseYear = "2025",
                Quantity = 1,
                SerialNumber = "N/A"
            },
            new Gear
            {
                Id = 15,
                GearTypeId = 3,
                Model = "Tambourine 8-inch Rock 'N' Roll Hall of Fame",
                PurchaseYear = "N/A",
                Quantity = 1,
                SerialNumber = "N/A"
            },
            new Gear
            {
                Id = 16,
                GearTypeId = 3,
                Model = "Tambourine 10-inch Meinl Nino",
                PurchaseYear = "2005",
                Quantity = 1,
                SerialNumber = "N/A"
            },
            new Gear
            {
                Id = 17,
                GearTypeId = 3,
                Model = "LP cowbell",
                PurchaseYear = "2006",
                Quantity = 1,
                SerialNumber = "N/A"
            },
            new Gear
            {
                Id = 18,
                GearTypeId = 4,
                Model = "Vic Firth SIH3 Isolation headphones",
                PurchaseYear = "N/A",
                Quantity = 1,
                SerialNumber = "N/A"
            },
            new Gear
            {
                Id = 19,
                GearTypeId = 4,
                Model = "Sennheiser HD 280 Pro headphones",
                PurchaseYear = "2025",
                Quantity = 1,
                SerialNumber = "N/A"
            },
            new Gear
            {
                Id = 20,
                GearTypeId = 4,
                Model = "Sterling MX5 monitor speakers pair",
                PurchaseYear = "2024",
                Quantity = 1,
                SerialNumber = "N/A"
            },
            new Gear
            {
                Id = 21,
                GearTypeId = 4,
                Model = "PreSonus Studio 1824c audio interface",
                PurchaseYear = "2024",
                Quantity = 1,
                SerialNumber = "SC4E24090030"
            },
            new Gear
            {
                Id = 22,
                GearTypeId = 5,
                Model = "On-Stage MS7920B Bass Drum/Boom Combo Mic Stand",
                PurchaseYear = "2024",
                Quantity = 3,
                SerialNumber = "N/A"
            },
            new Gear
            {
                Id = 23,
                GearTypeId = 5,
                Model = "JamStands JS-MSFB50 Low Profile Boom Mic Stand",
                PurchaseYear = "2024",
                Quantity = 2,
                SerialNumber = "N/A"
            },
            new Gear
            {
                Id = 24,
                GearTypeId = 5,
                Model = "K&M 21021 Extra Tall Boom Microphone Stand",
                PurchaseYear = "2024",
                Quantity = 2,
                SerialNumber = "N/A"
            },
            new Gear
            {
                Id = 25,
                GearTypeId = 2,
                Model = "Vocal pop filter",
                PurchaseYear = "2025",
                Quantity = 1,
                SerialNumber = "N/A"
            },
            new Gear
            {
                Id = 26,
                GearTypeId = 3,
                Model = "Ludwig Classic Series 1972 14x5 metal snare",
                PurchaseYear = "N/A",
                Quantity = 1,
                SerialNumber = "3019535"
            },
            new Gear
            {
                Id = 27,
                GearTypeId = 3,
                Model = "Ludwig maple snare 14x6.5",
                PurchaseYear = "2002",
                Quantity = 1,
                SerialNumber = "3390269"
            },
            new Gear
            {
                Id = 28,
                GearTypeId = 3,
                Model = "LP Vibra-slap",
                PurchaseYear = "2025",
                Quantity = 1,
                SerialNumber = "N/A"
            },
            new Gear
            {
                Id = 29,
                GearTypeId = 3,
                Model = "LP Sleigh Bells",
                PurchaseYear = "N/A",
                Quantity = 1,
                SerialNumber = "N/A"
            }
        });

        modelBuilder.Entity<GearType>().HasData(new GearType[]
        {
            new GearType { Id = 1, Name = "Computer" },
            new GearType { Id = 2, Name = "Microphone" },
            new GearType { Id = 3, Name = "Instrument" },
            new GearType { Id = 4, Name = "Recording" },
            new GearType { Id = 5, Name = "Stands" },
        });

        modelBuilder.Entity<Song>().HasData(new Song[]
        {
            new Song
            {
                Id = 1,
                Title = "Emily",
                Writer = "Josh Tinley",
                Artist = "Three Hit Combo",
                YearRecorded = 2026,
                StatusId = 2
            },
            new Song
            {
                Id = 2,
                Title = "Baby Don't Go (It's Christmas)",
                Writer = "Josh Tinley",
                Artist = "Three Hit Combo",
                YearRecorded = 2025,
                StatusId = 5
            },
            new Song
            {
                Id = 3,
                Title = "Mary Had a Baby (and the Baby Was the Lord)",
                Writer = "Josh Tinley",
                Artist = "Three Hit Combo",
                YearRecorded = 2025,
                StatusId = 5
            },
            new Song
            {
                Id = 4,
                Title = "Jolly Old St. Nick",
                Writer = "Josh Tinley",
                Artist = "Three Hit Combo",
                YearRecorded = 2025,
                StatusId = 5
            },
            new Song
            {
                Id = 5,
                Title = "What I Worry",
                Writer = "Josh Tinley",
                Artist = "Three Hit Combo",
                YearRecorded = 2025,
                StatusId = 1
            },
            new Song
            {
                Id = 6,
                Title = "The Black Hole in the Middle of the Galaxy",
                Writer = "Josh Tinley",
                Artist = "Three Hit Combo",
                YearRecorded = 2026,
                StatusId = 1
            },
            new Song
            {
                Id = 7,
                Title = "Morning Fog (Nothing Left to Be)",
                Writer = "Josh Tinley",
                Artist = "Three Hit Combo",
                YearRecorded = 2026,
                StatusId = 3
            },
            new Song
            {
                Id = 8,
                Title = "The Grief We've Earned",
                Writer = "Josh Tinley",
                Artist = "Three Hit Combo",
                YearRecorded = 2025,
                StatusId = 4
            },
            new Song
            {
                Id = 9,
                Title = "Rewasher",
                Writer = "Josh Tinley",
                Artist = "Three Hit Combo",
                YearRecorded = 2025,
                StatusId = 3
            }
        });

        modelBuilder.Entity<Status>().HasData(new Status[]
        {
            new Status { Id = 1, Name = "Recording" },
            new Status { Id = 2, Name = "Mixing" },
            new Status { Id = 3, Name = "Mastering" },
            new Status { Id = 4, Name = "Awaiting Release" },
            new Status { Id = 5, Name = "Released" }
        });

        modelBuilder.Entity<GearSong>().HasData(new GearSong[]
        {
            new GearSong { Id = 1, GearId = 1, SongId = 1 },
            new GearSong { Id = 2, GearId = 2, SongId = 1 },
            new GearSong { Id = 3, GearId = 3, SongId = 1 },
            new GearSong { Id = 4, GearId = 4, SongId = 1 },
            new GearSong { Id = 5, GearId = 5, SongId = 1 },
            new GearSong { Id = 6, GearId = 7, SongId = 1 },
            new GearSong { Id = 7, GearId = 8, SongId = 1 },
            new GearSong { Id = 8, GearId = 9, SongId = 1 },
            new GearSong { Id = 9, GearId = 10, SongId = 1 },
            new GearSong { Id = 10, GearId = 11, SongId = 1 },
            new GearSong { Id = 11, GearId = 15, SongId = 1 },
            new GearSong { Id = 12, GearId = 18, SongId = 1 },
            new GearSong { Id = 13, GearId = 19, SongId = 1 },
            new GearSong { Id = 14, GearId = 20, SongId = 1 },
            new GearSong { Id = 15, GearId = 21, SongId = 1 },
            new GearSong { Id = 16, GearId = 22, SongId = 1 },
            new GearSong { Id = 17, GearId = 23, SongId = 1 },
            new GearSong { Id = 18, GearId = 24, SongId = 1 },
            new GearSong { Id = 19, GearId = 25, SongId = 1 },
            new GearSong { Id = 20, GearId = 1, SongId = 2 },
            new GearSong { Id = 21, GearId = 2, SongId = 2 },
            new GearSong { Id = 22, GearId = 3, SongId = 2 },
            new GearSong { Id = 23, GearId = 4, SongId = 2 },
            new GearSong { Id = 24, GearId = 5, SongId = 2 },
            new GearSong { Id = 25, GearId = 7, SongId = 2 },
            new GearSong { Id = 26, GearId = 8, SongId = 2 },
            new GearSong { Id = 27, GearId = 9, SongId = 2 },
            new GearSong { Id = 28, GearId = 10, SongId = 2 },
            new GearSong { Id = 29, GearId = 11, SongId = 2 },
            new GearSong { Id = 30, GearId = 15, SongId = 2 },
            new GearSong { Id = 31, GearId = 18, SongId = 2 },
            new GearSong { Id = 32, GearId = 20, SongId = 2 },
            new GearSong { Id = 33, GearId = 21, SongId = 2 },
            new GearSong { Id = 34, GearId = 22, SongId = 2 },
            new GearSong { Id = 35, GearId = 23, SongId = 2 },
            new GearSong { Id = 36, GearId = 24, SongId = 2 },
            new GearSong { Id = 37, GearId = 25, SongId = 2 },
            new GearSong { Id = 38, GearId = 29, SongId = 2 },
        });
    }
}