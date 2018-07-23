import PriceEntryModel from './PriceEntryModel';

enum TravelExpenses {
    Covered,
    PartiallyCovered,
    NotCovered
}

class ConferenceModel {
    public id: string;
    public conferenceName: string;
    public city: string;
    public state: string;
    public country: string;
    public startDate: Date;
    public endDate: Date;
    public url: string;
    public prices: PriceEntryModel[];

    public cfpStartDate: Date;
    public cfpEndDate: Date;
    public cfpUrl: string;
    public travelAndExpenses: TravelExpenses;
}

export default ConferenceModel;