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
    public DbSet<UserProfile> UserProfiles { get; set; }

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
            Name = "Admin",
            NormalizedName = "admin"
        });

        modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
        {
            RoleId = "c3aaeb97-d2ba-4a53-a521-4eea61e59b35",
            UserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f"
        });

        modelBuilder.Entity<IdentityUser>().HasData(
        new IdentityUser
        {
            Id = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
            UserName = "Administrator",
            Email = "admina@strator.comx",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
        },
        new IdentityUser
        {
            Id = "8f7b2e4a-1c3d-4f6e-9a8b-5d2c1e0f3a4b",
            UserName = "ajohnson",
            Email = "ajohnson@signalchain.comx",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
        },
        new IdentityUser
        {
            Id = "2a4c6e8f-3b5d-4a7c-8e9f-1d3c5b7a9e0d",
            UserName = "rjohnson",
            Email = "rjohnson@signalchain.comx",
            PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(null, _configuration["AdminPassword"])
        }
        );

        modelBuilder.Entity<UserProfile>().HasData(
            new UserProfile
            {
                Id = 1,
                IdentityUserId = "dbc40bc6-0829-4ac5-a3ed-180f5e916a5f",
                FirstName = "Admina",
                LastName = "Strator",
                Address = "101 Main Street",
                UserName = "Administrator",
                Email = "admina@strator.comx",
            },
            new UserProfile
            {
                Id = 2,
                IdentityUserId = "8f7b2e4a-1c3d-4f6e-9a8b-5d2c1e0f3a4b",
                FirstName = "Andre",
                LastName = "Johnson",
                Address = "202 Oak Avenue",
                UserName = "ajohnson",
                Email = "ajohnson@signalchain.comx",
            },
            new UserProfile
            {
                Id = 3,
                IdentityUserId = "2a4c6e8f-3b5d-4a7c-8e9f-1d3c5b7a9e0d",
                FirstName = "Rainbow",
                LastName = "Johnson",
                Address = "202 Oak Avenue",
                UserName = "rjohnson",
                Email = "rjohnson@signalchain.comx",
            }
        );

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
                Model = "Studio Projects B1 Match Pair lrg dia mics",
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
                Model = "Fender 1105 SXE acoustic guitar",
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
                StatusId = 4
            },
            new Song
            {
                Id = 3,
                Title = "Mary Had a Baby (and the Baby Was the Lord)",
                Writer = "Josh Tinley",
                Artist = "Three Hit Combo",
                YearRecorded = 2025,
                StatusId = 4
            },
            new Song
            {
                Id = 4,
                Title = "Jolly Old St. Nick",
                Writer = "Josh Tinley",
                Artist = "Three Hit Combo",
                YearRecorded = 2025,
                StatusId = 4
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
                StatusId = 2
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
            new Status { Id = 4, Name = "Released" }
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
            new GearSong { Id = 39, GearId = 1, SongId = 3 },
            new GearSong { Id = 40, GearId = 2, SongId = 3 },
            new GearSong { Id = 41, GearId = 3, SongId = 3 },
            new GearSong { Id = 42, GearId = 4, SongId = 3 },
            new GearSong { Id = 43, GearId = 5, SongId = 3 },
            new GearSong { Id = 44, GearId = 7, SongId = 3 },
            new GearSong { Id = 45, GearId = 8, SongId = 3 },
            new GearSong { Id = 46, GearId = 9, SongId = 3 },
            new GearSong { Id = 47, GearId = 10, SongId = 3 },
            new GearSong { Id = 49, GearId = 12, SongId = 3 },
            new GearSong { Id = 50, GearId = 13, SongId = 3 },
            new GearSong { Id = 51, GearId = 14, SongId = 3 },
            new GearSong { Id = 52, GearId = 16, SongId = 3 },
            new GearSong { Id = 53, GearId = 18, SongId = 3 },
            new GearSong { Id = 54, GearId = 19, SongId = 3 },
            new GearSong { Id = 55, GearId = 20, SongId = 3 },
            new GearSong { Id = 56, GearId = 21, SongId = 3 },
            new GearSong { Id = 57, GearId = 22, SongId = 3 },
            new GearSong { Id = 58, GearId = 23, SongId = 3 },
            new GearSong { Id = 59, GearId = 24, SongId = 3 },
            new GearSong { Id = 60, GearId = 25, SongId = 3 },
            new GearSong { Id = 61, GearId = 26, SongId = 3 },
            new GearSong { Id = 62, GearId = 28, SongId = 3 },
            new GearSong { Id = 63, GearId = 29, SongId = 3 },
            new GearSong { Id = 64, GearId = 1, SongId = 4 },
            new GearSong { Id = 65, GearId = 2, SongId = 4 },
            new GearSong { Id = 66, GearId = 3, SongId = 4 },
            new GearSong { Id = 67, GearId = 4, SongId = 4 },
            new GearSong { Id = 68, GearId = 5, SongId = 4 },
            new GearSong { Id = 69, GearId = 7, SongId = 4 },
            new GearSong { Id = 70, GearId = 8, SongId = 4 },
            new GearSong { Id = 71, GearId = 9, SongId = 4 },
            new GearSong { Id = 72, GearId = 10, SongId = 4 },
            new GearSong { Id = 73, GearId = 12, SongId = 4 },
            new GearSong { Id = 74, GearId = 15, SongId = 4 },
            new GearSong { Id = 75, GearId = 17, SongId = 4 },
            new GearSong { Id = 76, GearId = 18, SongId = 4 },
            new GearSong { Id = 77, GearId = 20, SongId = 4 },
            new GearSong { Id = 78, GearId = 21, SongId = 4 },
            new GearSong { Id = 79, GearId = 22, SongId = 4 },
            new GearSong { Id = 80, GearId = 23, SongId = 4 },
            new GearSong { Id = 81, GearId = 24, SongId = 4 },
            new GearSong { Id = 82, GearId = 25, SongId = 4 },
            new GearSong { Id = 83, GearId = 27, SongId = 4 },
            new GearSong { Id = 84, GearId = 28, SongId = 4 },
            new GearSong { Id = 85, GearId = 29, SongId = 4 },
            new GearSong { Id = 86, GearId = 1, SongId = 5 },
            new GearSong { Id = 87, GearId = 2, SongId = 5 },
            new GearSong { Id = 88, GearId = 3, SongId = 5 },
            new GearSong { Id = 89, GearId = 4, SongId = 5 },
            new GearSong { Id = 90, GearId = 5, SongId = 5 },
            new GearSong { Id = 91, GearId = 7, SongId = 5 },
            new GearSong { Id = 92, GearId = 8, SongId = 5 },
            new GearSong { Id = 93, GearId = 9, SongId = 5 },
            new GearSong { Id = 94, GearId = 10, SongId = 5 },
            new GearSong { Id = 95, GearId = 11, SongId = 5 },
            new GearSong { Id = 96, GearId = 15, SongId = 5 },
            new GearSong { Id = 97, GearId = 18, SongId = 5 },
            new GearSong { Id = 98, GearId = 20, SongId = 5 },
            new GearSong { Id = 99, GearId = 21, SongId = 5 },
            new GearSong { Id = 100, GearId = 22, SongId = 5 },
            new GearSong { Id = 101, GearId = 23, SongId = 5 },
            new GearSong { Id = 102, GearId = 24, SongId = 5 },
            new GearSong { Id = 103, GearId = 25, SongId = 5 },
            new GearSong { Id = 104, GearId = 1, SongId = 6 },
            new GearSong { Id = 105, GearId = 2, SongId = 6 },
            new GearSong { Id = 106, GearId = 3, SongId = 6 },
            new GearSong { Id = 107, GearId = 4, SongId = 6 },
            new GearSong { Id = 108, GearId = 5, SongId = 6 },
            new GearSong { Id = 109, GearId = 6, SongId = 6 },
            new GearSong { Id = 110, GearId = 7, SongId = 6 },
            new GearSong { Id = 111, GearId = 9, SongId = 6 },
            new GearSong { Id = 112, GearId = 10, SongId = 6 },
            new GearSong { Id = 113, GearId = 12, SongId = 6 },
            new GearSong { Id = 114, GearId = 13, SongId = 6 },
            new GearSong { Id = 115, GearId = 15, SongId = 6 },
            new GearSong { Id = 116, GearId = 16, SongId = 6 },
            new GearSong { Id = 117, GearId = 18, SongId = 6 },
            new GearSong { Id = 118, GearId = 19, SongId = 6 },
            new GearSong { Id = 119, GearId = 20, SongId = 6 },
            new GearSong { Id = 120, GearId = 21, SongId = 6 },
            new GearSong { Id = 121, GearId = 22, SongId = 6 },
            new GearSong { Id = 122, GearId = 23, SongId = 6 },
            new GearSong { Id = 123, GearId = 24, SongId = 6 },
            new GearSong { Id = 124, GearId = 25, SongId = 6 },
            new GearSong { Id = 125, GearId = 27, SongId = 6 },
            new GearSong { Id = 126, GearId = 1, SongId = 7 },
            new GearSong { Id = 127, GearId = 2, SongId = 7 },
            new GearSong { Id = 128, GearId = 3, SongId = 7 },
            new GearSong { Id = 129, GearId = 4, SongId = 7 },
            new GearSong { Id = 130, GearId = 5, SongId = 7 },
            new GearSong { Id = 131, GearId = 7, SongId = 7 },
            new GearSong { Id = 132, GearId = 8, SongId = 7 },
            new GearSong { Id = 133, GearId = 9, SongId = 7 },
            new GearSong { Id = 134, GearId = 10, SongId = 7 },
            new GearSong { Id = 135, GearId = 11, SongId = 7 },
            new GearSong { Id = 136, GearId = 12, SongId = 7 },
            new GearSong { Id = 137, GearId = 14, SongId = 7 },
            new GearSong { Id = 138, GearId = 15, SongId = 7 },
            new GearSong { Id = 139, GearId = 18, SongId = 7 },
            new GearSong { Id = 140, GearId = 20, SongId = 7 },
            new GearSong { Id = 141, GearId = 21, SongId = 7 },
            new GearSong { Id = 142, GearId = 22, SongId = 7 },
            new GearSong { Id = 143, GearId = 23, SongId = 7 },
            new GearSong { Id = 144, GearId = 24, SongId = 7 },
            new GearSong { Id = 145, GearId = 25, SongId = 7 },
            new GearSong { Id = 146, GearId = 1, SongId = 8 },
            new GearSong { Id = 147, GearId = 2, SongId = 8 },
            new GearSong { Id = 148, GearId = 3, SongId = 8 },
            new GearSong { Id = 149, GearId = 4, SongId = 8 },
            new GearSong { Id = 150, GearId = 5, SongId = 8 },
            new GearSong { Id = 151, GearId = 7, SongId = 8 },
            new GearSong { Id = 152, GearId = 8, SongId = 8 },
            new GearSong { Id = 153, GearId = 9, SongId = 8 },
            new GearSong { Id = 154, GearId = 10, SongId = 8 },
            new GearSong { Id = 155, GearId = 12, SongId = 8 },
            new GearSong { Id = 156, GearId = 13, SongId = 8 },
            new GearSong { Id = 157, GearId = 16, SongId = 8 },
            new GearSong { Id = 158, GearId = 17, SongId = 8 },
            new GearSong { Id = 159, GearId = 18, SongId = 8 },
            new GearSong { Id = 160, GearId = 19, SongId = 8 },
            new GearSong { Id = 161, GearId = 20, SongId = 8 },
            new GearSong { Id = 162, GearId = 21, SongId = 8 },
            new GearSong { Id = 163, GearId = 22, SongId = 8 },
            new GearSong { Id = 164, GearId = 23, SongId = 8 },
            new GearSong { Id = 165, GearId = 24, SongId = 8 },
            new GearSong { Id = 166, GearId = 25, SongId = 8 },
            new GearSong { Id = 167, GearId = 26, SongId = 8 },
            new GearSong { Id = 168, GearId = 1, SongId = 9 },
            new GearSong { Id = 169, GearId = 2, SongId = 9 },
            new GearSong { Id = 170, GearId = 3, SongId = 9 },
            new GearSong { Id = 171, GearId = 4, SongId = 9 },
            new GearSong { Id = 172, GearId = 5, SongId = 9 },
            new GearSong { Id = 173, GearId = 7, SongId = 9 },
            new GearSong { Id = 174, GearId = 8, SongId = 9 },
            new GearSong { Id = 175, GearId = 9, SongId = 9 },
            new GearSong { Id = 176, GearId = 10, SongId = 9 },
            new GearSong { Id = 177, GearId = 11, SongId = 9 },
            new GearSong { Id = 178, GearId = 13, SongId = 9 },
            new GearSong { Id = 179, GearId = 15, SongId = 9 },
            new GearSong { Id = 180, GearId = 17, SongId = 9 },
            new GearSong { Id = 181, GearId = 18, SongId = 9 },
            new GearSong { Id = 182, GearId = 19, SongId = 9 },
            new GearSong { Id = 183, GearId = 20, SongId = 9 },
            new GearSong { Id = 184, GearId = 21, SongId = 9 },
            new GearSong { Id = 185, GearId = 22, SongId = 9 },
            new GearSong { Id = 186, GearId = 23, SongId = 9 },
            new GearSong { Id = 187, GearId = 24, SongId = 9 },
            new GearSong { Id = 188, GearId = 25, SongId = 9 },
            new GearSong { Id = 189, GearId = 28, SongId = 9 },
            new GearSong { Id = 190, GearId = 29, SongId = 9 }
        });
    }
}