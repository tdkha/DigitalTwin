using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Models;


namespace Data
{
    public static class BrowserData
    {
        public static Tab Youtube()
        {
            return new Tab("Youtube", 250.0f, 10.0f, 10.0f);
        }

        public static Tab Yle()
        {
            return new Tab("Yle", 150.0f, 8.0f, 8.0f);
        }
        public static Tab Reddit()
        {
            return new Tab("Reddit", 200.0f, 12.0f, 12.0f);
        }

    }

    public static class GameData
    {
        public static Game BaldurGate()
        {
            return new Game("Baldur's gate 3", 2500.0f, 40.0f, 50.0f);
        }

        public static Game CS2()
        {
            return new Game("CS2", 1500.0f, 40.0f, 40.0f);
        }
        public static Game LethalCompany ()
        {
            return new Game("Lethal Company", 200.0f, 20.0f, 20.0f);
        }

    }
}

