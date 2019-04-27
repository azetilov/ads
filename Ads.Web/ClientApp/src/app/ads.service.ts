import {Inject, Injectable} from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";
import {ChannelsListRepresentation} from "./models/hal/channelsListRepresentation";
import {AdsListRepresentation} from "./models/hal/adsListRepresentation";
import {Observable} from "rxjs";
import {AdsChannelsListRepresentation} from "./models/hal/adsChannelsListRepresentation";
import {Ad} from "./models/ad.model";
import {AdChannel} from "./models/ad-channel.model";

@Injectable({
  providedIn: 'root'
})
export class AdsService {
  private apiUrl: string;
  readonly halJson = {headers: new HttpHeaders({'Accept': 'application/hal+json; charset=utf-8'})};
  private http: HttpClient;

  constructor(http: HttpClient, @Inject('API_URL') apiUrl: string) {
    this.http = http;
    this.apiUrl = apiUrl;
  }
  getAds() : Observable<AdsListRepresentation> {
    return this.http.get<AdsListRepresentation>(this.apiUrl + '/ads', this.halJson);
  }

  public getAd(id: string) : Observable<Ad> {
    return this.http.get<Ad>(`${this.apiUrl}/ads/${id}`, this.halJson);
  }

  getChannels() : Observable<ChannelsListRepresentation> {
    return this.http.get<ChannelsListRepresentation>(this.apiUrl + '/channels', this.halJson);
  }

  getAdChannels(adId : number) : Observable<AdsChannelsListRepresentation> {
    return this.http.get<AdsChannelsListRepresentation>(`${this.apiUrl}/ads/${adId}/channels`, this.halJson);
  }

  addChannel(adChannel: AdChannel) : Observable<any> {
    return this.http.post(`${this.apiUrl}/ads/${adChannel.ad.id}/channels`, adChannel);
  }

  deleteChannel(adId: number, channelId: string) : Observable<any> {
    return this.http.delete(`${this.apiUrl}/ads/${adId}/channels/${channelId}`);
  }
}
