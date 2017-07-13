﻿using System;
using System.Reflection;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using HearthStoneSim.DragDrop;
using HearthStoneSimCore.Model;

namespace HearthStoneSim.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase, IDropTarget
   {
      private readonly IDataService _dataService;

      /// <summary>
      /// Get the window title (name and assembly version)
      /// </summary>
      public string MainWindowTitle { get; private set; }

      public Game Game { get; private set; }

      public HandViewModel HandViewModelPlayer1 { get; private set; }
      public HandViewModel HandViewModelPlayer2 { get; private set; }
      public BoardViewModel BoardViewModelPlayer1 { get; private set; }
      public BoardViewModel BoardViewModelPlayer2 { get; private set; }

      public void DragOver(IDropInfo dropInfo)
      {
         dropInfo.NotHandled = true;
      }

      public void Drop(IDropInfo dropInfo)
      {
         dropInfo.NotHandled = true;
      }

      /// <summary>
      /// Initializes a new instance of the MainViewModel class.
      /// </summary>
      public MainViewModel(IDataService dataService)
      {
         _dataService = dataService;

         Version deploy = Assembly.GetExecutingAssembly().GetName().Version;
         MainWindowTitle = $"HearthStoneSim v{deploy.Major}.{deploy.Minor}.{deploy.Build}";
         _dataService.GetCardDefs((cards, error) =>
         {
            if (error != null)
            {
                  // Report error here
                  return;
            }
            Cards.All = cards;
         });
         Game = new Game();

         HandViewModelPlayer1 = new HandViewModel(Game.Player1.Hand);
         HandViewModelPlayer2 = new HandViewModel(Game.Player2.Hand);
         BoardViewModelPlayer1 = new BoardViewModel(Game, Game.Player1.Board);
         BoardViewModelPlayer2 = new BoardViewModel(Game, Game.Player2.Board);

         MessengerInstance.Register<NotificationMessage>(this, NotifyMe);
      }

      public void NotifyMe(NotificationMessage notificationMessage)
      {
         //string notification = notificationMessage.Notification;
         BoardViewModelPlayer1.UpdateBoardState();
         BoardViewModelPlayer2.UpdateBoardState();
      }

      ////public override void Cleanup()
      ////{
      ////    // Clean up if needed

      ////    base.Cleanup();
      ////}
   }
}