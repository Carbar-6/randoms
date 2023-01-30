using System;
using System.Collections.Generic;
using TextGame.Locations;

namespace TextGame
{
    public class Game
    {
        //declaring world, allItems and NPC lists
        private List<Location> world;
        public static List <Item> allItems;
        private List <NPC> nPCs;

        //declaring and instantiating Player, Location and Item objects
        private Player player = new Player(20, 100);
        private static List<ICommandable> _allCommandableObjects = new List<ICommandable>();

        private Location plain = new Plain("plain", PlainDescriptions.plainDescription, PlainDescriptions.plainDescriptionShortDescription, "");
        private Location forest = new Forest("forest", ForestDescriptions.forestDescription, ForestDescriptions.forestShortDescription, ForestDescriptions.noBoarDescription);
        private Location cave = new Cave("cave", CaveDescriptions.caveDescription, CaveDescriptions.caveShortDescription, CaveDescriptions.caveNoItemDescription);
        private Location hall = new Hall("hall", HallDescription.hallDescription, HallDescription.hallDesciptionShort, HallDescription.hallNoItemDescription);
        private Location hut = new Hut("hut", HutDescription.hutDescription, HutDescription.hutDescriptionShort, "");
        private Location mountainSummit = new Mountain("mountain", MountainSummitDescriptions.MoutainSummitFirstDescription(), MountainSummitDescriptions.MountainSummitShortDescription(), MountainSummitDescriptions.MountainSummitNoItems());

        private Tool shovel = new Shovel(2.1, "Shovel", 10);
        private WearableItem robe = new Robe(3, "Robe", 20);
        private Tool flashlight = new Flashlight(1, "Flashlight", 6);
        private Tool proteinShake = new ProteinShake(0.5, "Proteinshake", 4);
        private Weapon sword = new Sword(5, "Sword", 35);
        private Coin coin = new Coin(0.1, "Coin", 1);

        private Interactions interactions = new Interactions();

        //declaring enemy NPCs
        private Boar boar;

        //declaring friendly NPCs
        private OldMan oldman;
        
        public Game()
        {
            //instantiating NPCs
            boar = new Boar(forest, "Boar", 20);
            oldman = new OldMan(hut, "Old man", 10);

            //add all locations, items and npcs to world arrays
            world = new List<Location> { plain, forest, cave, hall, hut, mountainSummit };
            allItems = new List<Item> { shovel, robe, flashlight, proteinShake, sword, coin };
            nPCs = new List<NPC> { boar, oldman };

            //populating location objects with neighbouring locations
            plain.AddNeigbouringAreas(cave, Directions.NORTH);
            plain.AddNeigbouringAreas(forest, Directions.EAST);
            forest.AddNeigbouringAreas(plain, Directions.WEST);
            forest.AddNeigbouringAreas(hut, Directions.EAST);
            cave.AddNeigbouringAreas(plain, Directions.SOUTH);
            cave.AddNeigbouringAreas(hall, Directions.WEST);
            hall.AddNeigbouringAreas(cave, Directions.EAST);
            hut.AddNeigbouringAreas(forest, Directions.WEST);
            hut.AddNeigbouringAreas(mountainSummit, Directions.NORTH);
            mountainSummit.AddNeigbouringAreas(hut, Directions.SOUTH);

            //adding items to locations
            cave.AddItemToArea(proteinShake);
            hall.AddItemToArea(sword);
            plain.AddItemToArea(coin);

            //adding NPCs to locations
            forest.AddNPCToLocation(boar);
            hut.AddNPCToLocation(oldman);

            SetUpCommandables();

            _allCommandableObjects.Add(interactions);

            //adding items to player inventory at the beginning of the game
            player.AddItemToInventory(shovel);
            player.AddItemToInventory(robe);
            player.AddItemToInventory(flashlight);

            //set bool to true to ensure describeYourself function runs on first loop
            player.HasMovedToNewLocation = true;

            //set start position for player
            player.Position = plain;

            //add one number of visit to starting location
            plain.NumberOfVisits++;
        }

        private void SetUpCommandables()
        {
            foreach (var location in world)
            {
                _allCommandableObjects.Add(location);
            }

            foreach (var item in allItems)
            {
                _allCommandableObjects.Add(item);
            }

            foreach (var npc in nPCs)
            {
                _allCommandableObjects.Add(npc);
            }
        }

        public void AddItemToAllCommandableObjects(Item itemToAdd)
        {
            _allCommandableObjects.Add(itemToAdd);
            player.ItemToAddToAllCommandableObject = null;
        }

        public void Run()
        {
            //Start of the game
            Console.Write("Welcome to the adventure game!\n" +
                "What is your name? ");

            player.Name = Console.ReadLine();

            Console.WriteLine($"\nHello {player.Name}, welcome to this magical world of wonder! You can move around by typing north/south/west/east. " +
                $"You will have to learn more commands as you play the game!(Hint: there is a command help).");

            bool gameIsNotFinished = true;

            //game loop
            while(gameIsNotFinished)
            {
                if (player.HasMovedToNewLocation)
                {
                    player.Position.describeYourself();
                    player.HasMovedToNewLocation = false;
                }

                Console.Write("\nWhat do you want to do? ");

                string input = Console.ReadLine();
                string[] command = input.Split(' ');

                foreach (var commandable in _allCommandableObjects)
                {
                    commandable.doCommand(command, player);
                }

                //check if player has any items that needs to be removed player equipment
                if (player.ItemInEquipmentToBeRemoved != null)
                {
                    player.RemoveItemFromInventory(player.ItemInEquipmentToBeRemoved);
                }
                //check if there are any NPC that needs to be removed from player location
                if (player.Position.NpcToBeRemoved != null)
                {
                    player.Position.RemoveNPCFromArea(player.Position.NpcToBeRemoved);
                }
                //check if there are any new ICommandable objects to add to the ICommandable list
                if (player.ItemToAddToAllCommandableObject != null)
                {
                    AddItemToAllCommandableObjects(player.ItemToAddToAllCommandableObject);
                }
                //check if player has completed the game
                if (player.PlayerHasCompletedTheGame)
                {
                    gameIsNotFinished = false;
                }
            }
            
            Console.WriteLine(" \n" +
                    "---------\n" +
                    " \n" +
                    "THE END\n");

            Console.ReadKey();
        }
    }
}
