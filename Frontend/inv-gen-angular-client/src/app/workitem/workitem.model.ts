export interface Address {
  street: string;
  city: string;
  postalCode: string;
  houseNumberIndicator: string;
}

export interface WorkItem {
  id: number;
  startTime: string;
  endTime: string;
  location: Address;
  rate: number;
  description: string;
  note: string;
  vatCode: VatCode;
}

export enum VatCode {
  Standard21 = 0
}