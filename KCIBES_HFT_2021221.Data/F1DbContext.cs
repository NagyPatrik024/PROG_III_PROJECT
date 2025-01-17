﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KCIBES_HFT_2021221.Models;

namespace KCIBES_HFT_2021221.Data
{
    public class F1DbContext : DbContext
    {
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Motor> Motors { get; set; }
        public F1DbContext()
        {
            this.Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                string conn =
                    @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\myDB.mdf;Integrated Security=True";
                builder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(conn);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Driver>(entity =>
            {
                entity
                .HasOne(driver => driver.Team)
                .WithMany(team => team.Drivers)
                .HasForeignKey(driver => driver.TeamId)
                .OnDelete(DeleteBehavior.SetNull);
            });
            modelBuilder.Entity<Driver>(entity =>
            {
                entity
                .HasOne(driver => driver.Motor)
                .WithMany(motor => motor.Drivers)
                .HasForeignKey(driver => driver.MotorId)
                .OnDelete(DeleteBehavior.SetNull);
            });
            modelBuilder.Entity<Team>(entity =>
            {
                entity
                .HasOne(team => team.Motor)
                .WithMany(motor => motor.Teams)
                .HasForeignKey(team => team.MotorId)
                .OnDelete(DeleteBehavior.SetNull);
            });


            Motor Ferrari = new Motor() { Id = 1, Type = "Ferrari 064" };
            Motor Mercedes = new Motor() { Id = 2, Type = "Mercedes M11 EQ" };
            Motor Honda = new Motor() { Id = 3, Type = "Honda RA620H" };
            Motor Renault = new Motor() { Id = 4, Type = "Renault E-Tech 20B" };
            Motor MotorDELETE = new Motor() { Id = 5, Type = "WILLBEDELETED" };
            Motor MotorUPDATE = new Motor() { Id = 6, Type = "WILLBEUPDATED" };


            Team TeamFerrari = new Team() { Id = 1, Name = "Ferrari", MotorId = 1, Team_Chief = "Mattia Binotto" };
            Team TeamMclaren = new Team() { Id = 2, Name = "Mclaren", MotorId = 2, Team_Chief = "Andreas Seidl" };
            Team TeamRedBull = new Team() { Id = 3, Name = "Red Bull Racing", MotorId = 3, Team_Chief = "Christian Horner" };
            Team TeamMercedes = new Team() { Id = 4, Name = "Mercedes", MotorId = 2, Team_Chief = "Toto Wolff" };
            Team TeamAlpine = new Team() { Id = 5, Name = "Alpine", MotorId = 4, Team_Chief = "Davide Brivio" };
            Team TeamAlphatauri = new Team() { Id = 6, Name = "Alphatauri", MotorId = 3, Team_Chief = "Franz Tost" };
            Team TeamAstonMartin = new Team() { Id = 7, Name = "Aston Martin", MotorId = 2, Team_Chief = "Andrew Green" };
            Team TeamWilliams = new Team() { Id = 8, Name = "Williams", MotorId = 2, Team_Chief = "Jost Capito" };
            Team TeamAlfaRomeo = new Team() { Id = 9, Name = "Alfa Romeo Racing", MotorId = 1, Team_Chief = "Frédéric Vasseur" };
            Team TeamHass = new Team() { Id = 10, Name = "Haas", MotorId = 1, Team_Chief = "Guenther Steiner" };
            Team TeamDELETE = new Team() { Id = 11, Name = "WILLBEDELETED", MotorId = 1, Team_Chief = "Guenther Steiner" };
            Team TeamUPDATE = new Team() { Id = 12, Name = "WILLBEUPDATED", MotorId = 1, Team_Chief = "Guenther Steiner" };



            Driver VER = new Driver() { Id = 1, Name = "Max Verstappen", Age = 24, Wins = 17, TeamId = 3, MotorId = 3 };
            Driver HAM = new Driver() { Id = 2, Name = "Lewis Hamilton", Age = 36, Wins = 100, TeamId = 4, MotorId = 2 };
            Driver BOT = new Driver() { Id = 3, Name = "Valtteri Bottas", Age = 32, Wins = 10, TeamId = 4, MotorId = 2 };
            Driver NOR = new Driver() { Id = 4, Name = "Lando Norris", Age = 22, Wins = 0, TeamId = 2, MotorId = 2 };
            Driver PER = new Driver() { Id = 5, Name = "Sergio Perez", Age = 31, Wins = 2, TeamId = 3, MotorId = 3 };
            Driver SAI = new Driver() { Id = 6, Name = "Carlos Sainz", Age = 27, Wins = 0, TeamId = 1, MotorId = 1 };
            Driver LEC = new Driver() { Id = 7, Name = "Charles Leclerc", Age = 24, Wins = 2, TeamId = 1, MotorId = 1 };
            Driver RIC = new Driver() { Id = 8, Name = "Daniel Ricciardo", Age = 32, Wins = 8, TeamId = 2, MotorId = 2 };
            Driver GAS = new Driver() { Id = 9, Name = "Pierre Gasly", Age = 25, Wins = 1, TeamId = 6, MotorId = 3 };
            Driver ALO = new Driver() { Id = 10, Name = "Fernando Alonso", Age = 40, Wins = 32, TeamId = 5, MotorId = 4 };
            Driver OCO = new Driver() { Id = 11, Name = "Esteban Ocon", Age = 25, Wins = 1, TeamId = 5, MotorId = 4 };
            Driver VET = new Driver() { Id = 12, Name = "Sebastian Vettel", Age = 34, Wins = 53, TeamId = 7, MotorId = 2 };
            Driver STR = new Driver() { Id = 13, Name = "Lance Stroll", Age = 23, Wins = 0, TeamId = 7, MotorId = 2 };
            Driver TSU = new Driver() { Id = 14, Name = "Yuki Tsunoda", Age = 21, Wins = 0, TeamId = 6, MotorId = 3 };
            Driver RUS = new Driver() { Id = 15, Name = "George Russel", Age = 23, Wins = 0, TeamId = 8, MotorId = 2 };
            Driver LAT = new Driver() { Id = 16, Name = "Nicholas Latifi", Age = 26, Wins = 0, TeamId = 8, MotorId = 2 };
            Driver RAI = new Driver() { Id = 17, Name = "Kimi Raikonnen", Age = 42, Wins = 21, TeamId = 9, MotorId = 1 };
            Driver GIO = new Driver() { Id = 18, Name = "Antonio Giovinazzi", Age = 28, Wins = 0, TeamId = 9, MotorId = 1 };
            Driver MSC = new Driver() { Id = 19, Name = "Mick Schumacher", Age = 22, Wins = 0, TeamId = 10, MotorId = 1 };
            Driver MAZ = new Driver() { Id = 20, Name = "Nikita Mazepin", Age = 22, Wins = 0, TeamId = 10, MotorId = 1 };
            Driver DriverDELETE = new Driver() { Id = 21, Name = "WILLBEDELETED", Age = 22, Wins = 0, TeamId = 10, MotorId = 1 };
            Driver DriverUPDATE = new Driver() { Id = 22, Name = "WILLBEUPDATED", Age = 22, Wins = 0, TeamId = 10, MotorId = 1 };

            modelBuilder.Entity<Motor>().HasData(Ferrari, Mercedes, Honda, Renault, MotorDELETE, MotorUPDATE);
            modelBuilder.Entity<Team>().HasData(TeamFerrari, TeamMclaren, TeamAlfaRomeo, TeamAlphatauri, TeamAlpine, TeamAstonMartin, TeamHass, TeamMercedes, TeamRedBull, TeamWilliams, TeamDELETE, TeamUPDATE);
            modelBuilder.Entity<Driver>().HasData( VER, HAM, BOT, NOR, PER, SAI, LEC, RIC, GAS, ALO, OCO, VET, STR, TSU, RUS, LAT, RAI, GIO, MSC, MAZ, DriverDELETE, DriverUPDATE);
        }
    }
}
