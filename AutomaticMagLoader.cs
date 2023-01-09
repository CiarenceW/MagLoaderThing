using Receiver2;
using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagLoaderThing {
	public class AutomaticMagLoader : Interactable {

		private int last_round_loaded_time = 0;

		public override void OnPressing() {
			LocalAimHandler localAimHandler;
			if (LocalAimHandler.TryGetInstance(out localAimHandler)) {
				LocalAimHandler.Hand hand = localAimHandler.hands[localAimHandler.GetHandWithState(LocalAimHandler.Hand.State.HoldingMag)];
				InventoryItem inventoryItem;

				if (
					localAimHandler.TryGetItemInHandWithState<InventoryItem>(LocalAimHandler.Hand.State.HoldingMag, out inventoryItem) 
					&& localAimHandler.LooseBulletCount > 0 
					&& hand.sub_state == LocalAimHandler.Hand.SubState.None
					&& last_round_loaded_time != (int) (Time.time * 10)
				) {
					localAimHandler.InsertRoundIntoMagazine(hand, inventoryItem, -0.001f);

					last_round_loaded_time = (int) (Time.time * 10);
				}
			}
		}

		public override bool CanInteract() {
			LocalAimHandler localAimHandler;
			return LocalAimHandler.TryGetInstance(out localAimHandler) && localAimHandler.IsHoldingMagazine && localAimHandler.GetHandWithState(LocalAimHandler.Hand.State.Idle) != -1;
		}
	}
}
