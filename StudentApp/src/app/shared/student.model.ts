export class Student {
        id:number=0;
        name:string='';
        email:string='';
        mobile:string='';
        stateId:number=0;
        cityId:number=0;
        stateName:string='';
        cityName:string='';
        aboutyourself:string='';
        photoid:number=0;
}

export class State{
  id:number=0;
  state_Name:number=0;
}

export class City{
  id:number=0;
  city_Name:string='';
  state_id:number=0;
}
