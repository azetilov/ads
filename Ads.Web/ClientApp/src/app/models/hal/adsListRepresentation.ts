import { Ad } from "../ad";

export class AdsListRepresentation {
  totalResults: number;
  _embedded : {
    ads: Array<Ad>
  };
}
