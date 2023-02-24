export default interface IUser {
  id: number;
  firstName: string;
  lastName: string;
  isAdmin: boolean;
}

export default class User implements IUser {
  constructor(options: IUser) {
    Object.assign(this, options);
  }

  id = 0;
  firstName = "";
  lastName = "";
  isAdmin = false;

  public get fullName(): string {
    return this.firstName + "" + this.lastName;
  }
}
