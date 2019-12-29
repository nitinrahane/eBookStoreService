import { Book } from './Book';

export interface CartItemDetails extends  Book {
      Quantity:number,
      AddedDate:string 
}

export interface CartItem  {
      ID:number,      
      UserID:number,
      BookID:number,
      Quantity:number,
      AddedDate:string,
      CartStaus:CartStaus
}




export enum CartStaus
{
    AddedToCart,
    OrderCompleted
}