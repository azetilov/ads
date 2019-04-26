import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {AdsListRepresentation} from "../../models/hal/adsListRepresentation";
import {Ad} from "../../models/ad";
import {ChannelsListRepresentation} from "../../models/hal/channelsListRepresentation";
import {Channel} from "../../models/channel";
import {AdChannel} from "../../models/ad-channel";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  public ads: Ad[];
  public channels: Channel[];
  public adsChannels: { [s: string]: AdChannel; } = {};

  constructor(http: HttpClient, @Inject('API_URL') apiUrl: string) {
    http.get<ChannelsListRepresentation>(apiUrl + '/channels').subscribe(result => {
      this.channels = result._embedded.channels;
    }, error => console.error(error));
    http.get<AdsListRepresentation>(apiUrl + '/ads').subscribe(result => {
      this.ads = result._embedded.ads;
      this.ads.forEach(ad => {
        http.get<AdsChannelsRepresentation>(apiUrl + `/ads/${ad.id}/channels`).subscribe(result => {
          this.adsChannels[ad.id] = result._embedded.adsChannels;
        }, error => console.error(error));
      })
    }, error => console.error(error));
  }
}
