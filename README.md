NHibernate Linq Inner Join Fetch provider
=========================================

This simple library aims to provide support for NHibernate to perform inner join eager fetching.


# Enable Inner Joins

The call to 

    NHibernateInnerJoinSupport.Enable() 

must be performed at any time before NHibernate intializes

# Performing inner joins

I've provided ffour extension methods to support inner join

* InnerFetch
* InnerFetchMany
* ThenInnerFetch
* ThenInnerFetchMany

They live in the NHibernate.Linq namespace
