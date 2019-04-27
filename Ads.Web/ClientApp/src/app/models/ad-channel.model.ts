import {Channel} from "./channel.model";
import {Ad} from "./ad.model";

export class AdChannel {
  id: number;
  name: string;
  channel: Channel;
  ad: Ad;
}

