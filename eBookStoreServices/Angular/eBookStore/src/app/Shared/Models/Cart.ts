import { Book } from './Book';

export interface CartItemDetails extends  Book {
      Quantity:number,
      AddedDate:Date 
}

export interface CartItem {
      ID:number,
      UserID:number,
      BookID:number,
      Quantity:number,
      AddedDate:Date,
      CartStaus:CartStaus
}




export enum CartStaus
{
    AddedToCart,
    OrderCompleted
}