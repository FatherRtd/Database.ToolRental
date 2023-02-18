import Category from "./Category";

export default interface IProduct {
  id: number,
  name: string,
  shortDescription: string,
  longDescription: string,
  rentalPrice: number,
  isInStock: boolean,
  imageSrc: string,
  category: Category | null,
}

export default class Product implements IProduct{
  constructor(options: IProduct) {
    Object.assign(this, options);

    this.category = options.category == null ? null : new Category(options.category);
  }

  id = 0;
  name = "";
  shortDescription = "";
  longDescription = "";
  rentalPrice = 0;
  isInStock = false;
  imageSrc = ""
  category: Category | null = null;
}