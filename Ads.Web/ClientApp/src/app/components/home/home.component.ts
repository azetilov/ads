import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {AdsListRepresentation} from "../../models/hal/adsListRepresentation";
import {Ad} from "../../models/ad";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public ads: Ad[];
  public channels: Channel[];

  constructor(http: HttpClient, @Inject('API_URL') apiUrl: string) {
    http.get<ChannelsListRepresentation>(apiUrl + '/channels').subscribe(result => {
      console.log(result);
      this.channels = result._embedded.channels;
    }, error => console.error(error));
    http.get<AdsListRepresentation>(apiUrl + '/ads').subscribe(result => {
      console.log(result);
      this.ads = result._embedded.ads;
    }, error => console.error(error));
  }
}
