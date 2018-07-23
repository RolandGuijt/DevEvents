import * as React from "react";
import ConferenceModel from "../Models/ConferenceModel";
import ConferenceList from "./conference-list";

class MainPage extends React.Component<{}, {}> {
    private conferences: ConferenceModel[];
    
    public componentDidMount() {
        this.fetchConferences();
    }

    public render(): React.ReactNode {
        if (this.conferences) {
            return (
                <ConferenceList conferences={this.conferences}/>
            );
        }
        return (
            <div>No results</div>
        );
    }
    
    private fetchConferences = () => {
        fetch('https://localhost:5001/v1/Conference')
            .then(rsp => rsp.json())
            .then(conferences => this.conferences = conferences);
    }
}

export default MainPage;