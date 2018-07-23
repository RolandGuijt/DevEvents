import * as React from 'react';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';
import ConferenceModel from '../Models/ConferenceModel';

interface IProps {
    conferences: ConferenceModel[];
}

class ConferenceList extends React.Component<IProps, {}> {
    public render(): React.ReactNode {
        return (
            <Paper>
                <Table>
                    <TableHead>
                        <TableRow>
                            <TableCell>Name</TableCell>
                            <TableCell>City</TableCell>
                            <TableCell>State</TableCell>
                            <TableCell>Country</TableCell>
                            <TableCell>Date</TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {this.props.conferences.map(c => {
                            return (
                                <TableRow key={c.id}>
                                    <TableCell component="th" scope="row">
                                        {c.conferenceName}
                                    </TableCell>
                                    <TableCell>{c.city}</TableCell>
                                    <TableCell>{c.state}</TableCell>
                                    <TableCell>{c.country}</TableCell>
                                    <TableCell>{c.startDate}</TableCell>
                                </TableRow>
                            );
                        })}
                    </TableBody>
                </Table>
            </Paper>
        );
    }
}

export default ConferenceList;