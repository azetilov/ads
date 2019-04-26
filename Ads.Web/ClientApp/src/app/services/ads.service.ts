import { Injectable } from '@angular/core';
import { Ad } from "../models/ad";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";

const CONTENT_TYPE = {
  HAL_JSON: 'application/hal+json; charset=utf-8',
  JSON: 'application/json'
};

@Injectable({
  providedIn: 'root'
})
export class AdsService {
  url = 'http://localhost:5000/api/v1/ads/';

  constructor(private http: HttpClient) { }

  getAllAds(): Observable<Ad[]> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': CONTENT_TYPE.HAL_JSON}) };
    return this.http.get<Ad[]>(this.url, httpOptions);
  }
  getAdById(id: string): Observable<Ad> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': CONTENT_TYPE.HAL_JSON}) };
    return this.http.get<Ad>(this.url + id, httpOptions);
  }
  createAd(ad: Ad): Observable<Ad> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': CONTENT_TYPE.JSON }) };
    return this.http.post<Ad>(this.url, ad, httpOptions);
  }
  updateAd(ad: Ad): Observable<Ad> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': CONTENT_TYPE.JSON}) };
    return this.http.put<Ad>(this.url, ad, httpOptions);
  }
  deleteAd(id: string): Observable<number> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': CONTENT_TYPE.JSON}) };
    return this.http.delete<number>(this.url + id, httpOptions);
  }
}
