import { Ad } from "../ad.model";

export class AdsListRepresentation {
  totalResults: number;
  _embedded : {
    ads: Array<Ad>
  };
}
