export class Profile{
  constructor(data){
    this.id = data.id
    this.name = data.name
    this.picture = data.picture
  }
}

export class Account extends Profile {
  constructor(data) {
    super(data)
    this.email = data.email
    // TODO add additional properties if needed
  }
}

export class Cultist extends Profile{
  constructor(data){
    super(data)
      this.cultMemberId = data.cultMemberId
  }
}
