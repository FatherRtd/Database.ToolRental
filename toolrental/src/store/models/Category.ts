export default interface ICategory {
  id: number;
  name: string;
  parentCategory: ICategory | null;
}

export default class Category implements ICategory {
  constructor(options: ICategory) {
    Object.assign(this, options);

    this.parentCategory =
      options.parentCategory == null ? null : options.parentCategory;
  }

  id = 0;
  name = "";
  parentCategory: ICategory | null = null;
}
