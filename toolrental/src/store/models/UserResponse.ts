import User from "./User";

export default interface IUserResponse {
  token: string;
  user: User | null;
}

export default class UserResponse implements IUserResponse {
  constructor(options: IUserResponse) {
    Object.assign(this, options);
    this.user = options.user == null ? null : new User(options.user);
  }

  token = "";
  user: User | null = null;
}
