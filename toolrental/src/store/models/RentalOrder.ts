import Product from "./Product";
import User from "./User";

export interface IRentalOrder {
  id: number;
  user: User | null;
  product: Product | null;
  orderDate: Date | null;
  orderEndDate: Date | null;
  rentalPrice: number;
  isDone: boolean;
}

export default class RentalOrder implements IRentalOrder {
  constructor(options: IRentalOrder) {
    Object.assign(this, options);

    this.product =
      options.product == null ? null : new Product(options.product);
    this.user = options.user == null ? null : new User(options.user);
  }

  id = 0;
  user: User | null = null;
  product: Product | null = null;
  orderDate: Date | null = null;
  orderEndDate: Date | null = null;
  rentalPrice = 0;
  isDone = false;

  public get productName(): string {
    if (this.product?.name == null) {
      return "";
    } else {
      return this.product?.name;
    }
  }

  public get userName(): string {
    if (this.user?.fullName == null) {
      return "";
    } else {
      return this.user?.fullName;
    }
  }

  public get orderStatus(): string {
    return this.isDone ? "Завершён" : "В процессе";
  }
}
